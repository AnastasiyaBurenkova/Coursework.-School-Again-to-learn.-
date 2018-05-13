using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractShopService.ImplementationsList
{
    public class BonusFineBlockServiceList : IBonusFineBlockService
    {
        private DataListSingleton source;

        public BonusFineBlockServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<BonusFineBlockViewModel> GetList()
        {
            List<BonusFineBlockViewModel> result = source.BonusFineBlocks
                .Select(rec => new BonusFineBlockViewModel
                {
                    Id = rec.Id,
                    BonusFineBlockName = rec.BonusFineBlockName,
                    BonusFineBlockPayments = source.BonusFineBlockPayments
                            .Where(recPC => recPC.BonusFineBlockId == rec.Id)
                            .Select(recPC => new BonusFineBlockZakazchikViewModel
                            {
                                Id = recPC.Id,
                                BonusFineBlockId = recPC.BonusFineBlockId,
                                ZakazchikId = recPC.ZakazchikId,
                                ZakazchikName = source.Payments
                                    .FirstOrDefault(recC => recC.Id == recPC.ZakazchikId)?.PaymentName,
                                Count = recPC.Count
                            })
                            .ToList()
                })
                .ToList();
            return result;
        }

        public BonusFineBlockViewModel GetElement(int id)
        {
            BonusFineBlock element = source.BonusFineBlocks.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new BonusFineBlockViewModel
                {
                    Id = element.Id,
                    BonusFineBlockName = element.BonusFineBlockName,
                    BonusFineBlockPayments = source.BonusFineBlockPayments
                            .Where(recPC => recPC.BonusFineBlockId == element.Id)
                            .Select(recPC => new BonusFineBlockZakazchikViewModel
                            {
                                Id = recPC.Id,
                                BonusFineBlockId = recPC.BonusFineBlockId,
                                ZakazchikId = recPC.ZakazchikId,
                                ZakazchikName = source.Payments
                                    .FirstOrDefault(recC => recC.Id == recPC.ZakazchikId)?.PaymentName,
                                Count = recPC.Count
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(BonusFineBlockBindingModel model)
        {
            BonusFineBlock element = source.BonusFineBlocks.FirstOrDefault(rec => rec.BonusFineBlockName == model.BonusFineBlockName);
            if (element != null)
            {
                throw new Exception("Уже есть Бонус, Штраф или Блокировка с таким названием");
            }
            int maxId = source.BonusFineBlocks.Count > 0 ? source.BonusFineBlocks.Max(rec => rec.Id) : 0;
            source.BonusFineBlocks.Add(new BonusFineBlock
            {
                Id = maxId + 1,
                BonusFineBlockName = model.BonusFineBlockName
            });
        }

        public void UpdElement(BonusFineBlockBindingModel model)
        {
            BonusFineBlock element = source.BonusFineBlocks.FirstOrDefault(rec =>
                                        rec.BonusFineBlockName == model.BonusFineBlockName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть Бонус, Штраф или Блокировка с таким названием");
            }
            element = source.BonusFineBlocks.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.BonusFineBlockName = model.BonusFineBlockName;
        }

        public void DelElement(int id)
        {
            BonusFineBlock element = source.BonusFineBlocks.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // при удалении удаляем все записи о компонентах на удаляемом складе
                source.BonusFineBlockPayments.RemoveAll(rec => rec.BonusFineBlockId == id);
                source.BonusFineBlocks.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}