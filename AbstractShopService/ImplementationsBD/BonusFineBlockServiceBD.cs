using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractShopService.ImplementationsBD
{
    public class BonusFineBlockServiceBD : IBonusFineBlockService
    {
        private AbstractDbContext context;

        public BonusFineBlockServiceBD(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<BonusFineBlockViewModel> GetList()
        {
            List<BonusFineBlockViewModel> result = context.BonusFineBlocks
                .Select(rec => new BonusFineBlockViewModel
                {
                    Id = rec.Id,
                    BonusFineBlockName = rec.BonusFineBlockName,
                    BonusFineBlockPayments = context.BonusFineBlockPayments
                            .Where(recPC => recPC.BonusFineBlockId == rec.Id)
                            .Select(recPC => new BonusFineBlockZakazchikViewModel
                            {
                                Id = recPC.Id,
                                BonusFineBlockId = recPC.BonusFineBlockId,
                                ZakazchikId = recPC.ZakazchikId,
                                ZakazchikName = recPC.Zakazchik.ZakazchikFIO,
                                Count = recPC.Count
                            })
                            .ToList()
                })
                .ToList();
            return result;
        }

        public BonusFineBlockViewModel GetElement(int id)
        {
            BonusFineBlock element = context.BonusFineBlocks.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new BonusFineBlockViewModel
                {
                    Id = element.Id,
                    BonusFineBlockName = element.BonusFineBlockName,
                    BonusFineBlockPayments = context.BonusFineBlockPayments
                            .Where(recPC => recPC.BonusFineBlockId == element.Id)
                            .Select(recPC => new BonusFineBlockZakazchikViewModel
                            {
                                Id = recPC.Id,
                                BonusFineBlockId = recPC.BonusFineBlockId,
                                ZakazchikId = recPC.ZakazchikId,
                                ZakazchikName = recPC.Zakazchik.ZakazchikFIO,
                                Count = recPC.Count
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(BonusFineBlockBindingModel model)
        {
            BonusFineBlock element = context.BonusFineBlocks.FirstOrDefault(rec => rec.BonusFineBlockName == model.BonusFineBlockName);
            if (element != null)
            {
                throw new Exception("Уже есть Бонус, Штраф или Блокировка с таким названием");
            }
            context.BonusFineBlocks.Add(new BonusFineBlock
            {
                BonusFineBlockName = model.BonusFineBlockName
            });
            context.SaveChanges();
        }

        public void UpdElement(BonusFineBlockBindingModel model)
        {
            BonusFineBlock element = context.BonusFineBlocks.FirstOrDefault(rec =>
                                        rec.BonusFineBlockName == model.BonusFineBlockName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть Бонус, Штраф или Блокировка с таким названием");
            }
            element = context.BonusFineBlocks.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.BonusFineBlockName = model.BonusFineBlockName;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    BonusFineBlock element = context.BonusFineBlocks.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        // при удалении удаляем все записи о компонентах на удаляемом складе
                        context.BonusFineBlockPayments.RemoveRange(
                                            context.BonusFineBlockPayments.Where(rec => rec.BonusFineBlockId == id));
                        context.BonusFineBlocks.Remove(element);
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