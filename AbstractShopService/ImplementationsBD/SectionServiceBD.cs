using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AbstractShopService.ImplementationsBD
{
    public class SectionServiceBD : ISectionService
    {
        private AbstractDbContext context;

        public SectionServiceBD(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<SectionViewModel> GetList()
        {
            List<SectionViewModel> result = context.Sections
                .Select(rec => new SectionViewModel
                {
                    Id = rec.Id,
                    SectionName = rec.SectionName,
                    Price = rec.Price,
                    SectionPayments = context.SectionPayments
                            .Where(recPC => recPC.SectionId == rec.Id)
                            .Select(recPC => new SectionPaymentViewModel
                            {
                                Id = recPC.Id,
                                SectionId = recPC.SectionId,
                                PaymentId = recPC.PaymentId,
                                PaymentName = recPC.Payment.PaymentName,
                                Count = recPC.Count
                            })
                            .ToList()
                })
                .ToList();
            return result;
        }

        public SectionViewModel GetElement(int id)
        {
            Section element = context.Sections.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new SectionViewModel
                {
                    Id = element.Id,
                    SectionName = element.SectionName,
                    Price = element.Price,
                    SectionPayments = context.SectionPayments
                            .Where(recPC => recPC.SectionId == element.Id)
                            .Select(recPC => new SectionPaymentViewModel
                            {
                                Id = recPC.Id,
                                SectionId = recPC.SectionId,
                                PaymentId = recPC.PaymentId,
                                PaymentName = recPC.Payment.PaymentName,
                                Count = recPC.Count
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(SectionBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Section element = context.Sections.FirstOrDefault(rec => rec.SectionName == model.SectionName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть кружок с таким названием");
                    }
                    element = new Section
                    {
                        SectionName = model.SectionName,
                        Price = model.Price
                    };
                    context.Sections.Add(element);
                    context.SaveChanges();
                    // убираем дубли по компонентам
                    var groupPayments = model.SectionPayments
                                                .GroupBy(rec => rec.PaymentId)
                                                .Select(rec => new
                                                {
                                                    PaymentId = rec.Key,
                                                    Count = rec.Sum(r => r.Count)
                                                });
                    // добавляем компоненты
                    foreach (var groupPayment in groupPayments)
                    {
                        context.SectionPayments.Add(new SectionPayment
                        {
                            SectionId = element.Id,
                            PaymentId = groupPayment.PaymentId,
                            Count = groupPayment.Count
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void UpdElement(SectionBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Section element = context.Sections.FirstOrDefault(rec =>
                                        rec.SectionName == model.SectionName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть кружок с таким названием");
                    }
                    element = context.Sections.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.SectionName = model.SectionName;
                    element.Price = model.Price;
                    context.SaveChanges();

                    // обновляем существуюущие компоненты
                    var compIds = model.SectionPayments.Select(rec => rec.PaymentId).Distinct();
                    var updatePayments = context.SectionPayments
                                                    .Where(rec => rec.SectionId == model.Id &&
                                                        compIds.Contains(rec.PaymentId));
                    foreach (var updatePayment in updatePayments)
                    {
                        updatePayment.Count = model.SectionPayments
                                                        .FirstOrDefault(rec => rec.Id == updatePayment.Id).Count;
                    }
                    context.SaveChanges();
                    context.SectionPayments.RemoveRange(
                                        context.SectionPayments.Where(rec => rec.SectionId == model.Id &&
                                                                            !compIds.Contains(rec.PaymentId)));
                    context.SaveChanges();
                    // новые записи
                    var groupPayments = model.SectionPayments
                                                .Where(rec => rec.Id == 0)
                                                .GroupBy(rec => rec.PaymentId)
                                                .Select(rec => new
                                                {
                                                    PaymentId = rec.Key,
                                                    Count = rec.Sum(r => r.Count)
                                                });
                    foreach (var groupPayment in groupPayments)
                    {
                        SectionPayment elementPC = context.SectionPayments
                                                .FirstOrDefault(rec => rec.SectionId == model.Id &&
                                                                rec.PaymentId == groupPayment.PaymentId);
                        if (elementPC != null)
                        {
                            elementPC.Count += groupPayment.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.SectionPayments.Add(new SectionPayment
                            {
                                SectionId = model.Id,
                                PaymentId = groupPayment.PaymentId,
                                Count = groupPayment.Count
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Section element = context.Sections.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.SectionPayments.RemoveRange(
                                            context.SectionPayments.Where(rec => rec.SectionId == id));
                        context.Sections.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
