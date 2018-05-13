using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractShopService.ImplementationsList
{
    public class MainServiceList : IMainService
    {
        private DataListSingleton source;

        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<ZakazViewModel> GetList()
        {
            List<ZakazViewModel> result = source.Zakazs
                .Select(rec => new ZakazViewModel
                {
                    Id = rec.Id,
                    ZakazchikId = rec.ZakazchikId,
                    SectionId = rec.SectionId,
                    RabochiId = rec.RabochiId,
                    DateCreate = rec.DateCreate.ToLongDateString(),
                    DateImplement = rec.DateImplement?.ToLongDateString(),
                    Status = rec.Status.ToString(),
                    Count = rec.Count,
                    Sum = rec.Sum,
                    ZakazchikFIO = source.Zakazchiks
                                    .FirstOrDefault(recC => recC.Id == rec.ZakazchikId)?.ZakazchikFIO,
                    SectionName = source.Sections
                                    .FirstOrDefault(recP => recP.Id == rec.SectionId)?.SectionName,
                    RabochiName = source.Rabochis
                                    .FirstOrDefault(recI => recI.Id == rec.RabochiId)?.RabochiFIO
                })
                .ToList();
            return result;
        }

        public void CreateZakaz(ZakazBindingModel model)
        {
            int maxId = source.Zakazs.Count > 0 ? source.Zakazs.Max(rec => rec.Id) : 0;
            source.Zakazs.Add(new Zakaz
            {
                Id = maxId + 1,
                ZakazchikId = model.ZakazchikId,
                SectionId = model.SectionId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = PaymentStatus.Подана_заявка
            });
        }

        public void TakeZakazInWork(ZakazBindingModel model)
        {
            Zakaz element = source.Zakazs.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            // смотрим по количеству компонентов на складах
            var SectionPayments = source.SectionPayments.Where(rec => rec.SectionId == element.SectionId);
            foreach (var SectionPayment in SectionPayments)
            {
                int countOnBonusFineBlocks = source.BonusFineBlockPayments
                                            .Where(rec => rec.ZakazchikId == SectionPayment.PaymentId)
                                            .Sum(rec => rec.Count);
                if (countOnBonusFineBlocks < SectionPayment.Count * element.Count)
                {
                    var PaymentName = source.Payments
                                    .FirstOrDefault(rec => rec.Id == SectionPayment.PaymentId);
                    throw new Exception("Не достаточно выплат " + PaymentName?.PaymentName +
                        " требуется " + SectionPayment.Count + ", в наличии " + countOnBonusFineBlocks);
                }
            }
            
            element.RabochiId = model.RabochiId;
            element.DateImplement = DateTime.Now;
            element.Status = PaymentStatus.Заявка_принята;
        }

        public void FinishZakaz(int id)
        {
            Zakaz element = source.Zakazs.FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Status = PaymentStatus.Задолженность;
        }

        public void PayZakaz(int id)
        {
            Zakaz element = source.Zakazs.FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Status = PaymentStatus.Оплачен;
        }

        public void PutZakazchikOnBonusFineBlock(BonusFineBlockZakazchikBindingModel model)
        {
            BonusFineBlockZakazchik element = source.BonusFineBlockPayments
                                                .FirstOrDefault(rec => rec.BonusFineBlockId == model.BonusFineBlockId &&
                                                                    rec.ZakazchikId == model.ZakazchikId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                int maxId = source.BonusFineBlockPayments.Count > 0 ? source.BonusFineBlockPayments.Max(rec => rec.Id) : 0;
                source.BonusFineBlockPayments.Add(new BonusFineBlockZakazchik
                {
                    Id = ++maxId,
                    BonusFineBlockId = model.BonusFineBlockId,
                    ZakazchikId = model.ZakazchikId,
                    Count = model.Count
                });
            }
        }
    }
}