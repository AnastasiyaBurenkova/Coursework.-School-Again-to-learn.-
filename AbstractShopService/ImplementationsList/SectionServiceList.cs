using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractShopService.ImplementationsList
{
    public class SectionServiceList : ISectionService
    {
        private DataListSingleton source;

        public SectionServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<SectionViewModel> GetList()
        {
            List<SectionViewModel> result = source.Sections
                .Select(rec => new SectionViewModel
                {
                    Id = rec.Id,
                    SectionName = rec.SectionName,
                    Price = rec.Price,
                    SectionPayments = source.SectionPayments
                            .Where(recPC => recPC.SectionId == rec.Id)
                            .Select(recPC => new SectionPaymentViewModel
                            {
                                Id = recPC.Id,
                                SectionId = recPC.SectionId,
                                PaymentId = recPC.PaymentId,
                                PaymentName = source.Payments
                                    .FirstOrDefault(recC => recC.Id == recPC.PaymentId)?.PaymentName,
                                Count = recPC.Count
                            })
                            .ToList()
                })
                .ToList();
            return result;
        }

        public SectionViewModel GetElement(int id)
        {
            Section element = source.Sections.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new SectionViewModel
                {
                    Id = element.Id,
                    SectionName = element.SectionName,
                    Price = element.Price,
                    SectionPayments = source.SectionPayments
                            .Where(recPC => recPC.SectionId == element.Id)
                            .Select(recPC => new SectionPaymentViewModel
                            {
                                Id = recPC.Id,
                                SectionId = recPC.SectionId,
                                PaymentId = recPC.PaymentId,
                                PaymentName = source.Payments
                                        .FirstOrDefault(recC => recC.Id == recPC.PaymentId)?.PaymentName,
                                Count = recPC.Count
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(SectionBindingModel model)
        {
            Section element = source.Sections.FirstOrDefault(rec => rec.SectionName == model.SectionName);
            if (element != null)
            {
                throw new Exception("Уже есть кружок с таким названием");
            }
            int maxId = source.Sections.Count > 0 ? source.Sections.Max(rec => rec.Id) : 0;
            source.Sections.Add(new Section
            {
                Id = maxId + 1,
                SectionName = model.SectionName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = source.SectionPayments.Count > 0 ?
                                    source.SectionPayments.Max(rec => rec.Id) : 0;
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
                source.SectionPayments.Add(new SectionPayment
                {
                    Id = ++maxPCId,
                    SectionId = maxId + 1,
                    PaymentId = groupPayment.PaymentId,
                    Count = groupPayment.Count
                });
            }
        }

        public void UpdElement(SectionBindingModel model)
        {
            Section element = source.Sections.FirstOrDefault(rec =>
                                        rec.SectionName == model.SectionName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть кружок с таким названием");
            }
            element = source.Sections.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.SectionName = model.SectionName;
            element.Price = model.Price;

            int maxPCId = source.SectionPayments.Count > 0 ? source.SectionPayments.Max(rec => rec.Id) : 0;
            // обновляем существуюущие компоненты
            var compIds = model.SectionPayments.Select(rec => rec.PaymentId).Distinct();
            var updatePayments = source.SectionPayments
                                            .Where(rec => rec.SectionId == model.Id &&
                                           compIds.Contains(rec.PaymentId));
            foreach (var updatePayment in updatePayments)
            {
                updatePayment.Count = model.SectionPayments
                                                .FirstOrDefault(rec => rec.Id == updatePayment.Id).Count;
            }
            source.SectionPayments.RemoveAll(rec => rec.SectionId == model.Id &&
                                       !compIds.Contains(rec.PaymentId));
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
                SectionPayment elementPC = source.SectionPayments
                                        .FirstOrDefault(rec => rec.SectionId == model.Id &&
                                                        rec.PaymentId == groupPayment.PaymentId);
                if (elementPC != null)
                {
                    elementPC.Count += groupPayment.Count;
                }
                else
                {
                    source.SectionPayments.Add(new SectionPayment
                    {
                        Id = ++maxPCId,
                        SectionId = model.Id,
                        PaymentId = groupPayment.PaymentId,
                        Count = groupPayment.Count
                    });
                }
            }
        }

        public void DelElement(int id)
        {
            Section element = source.Sections.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // удаяем записи по компонентам при удалении изделия
                source.SectionPayments.RemoveAll(rec => rec.SectionId == id);
                source.Sections.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}