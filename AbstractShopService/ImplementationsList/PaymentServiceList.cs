using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractShopService.ImplementationsList
{
    public class PaymentServiceList : IPaymentService
    {
        private DataListSingleton source;

        public PaymentServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<PaymentViewModel> GetList()
        {
            List<PaymentViewModel> result = source.Payments
                .Select(rec => new PaymentViewModel
                {
                    Id = rec.Id,
                    PaymentName = rec.PaymentName
                })
                .ToList();
            return result;
        }

        public PaymentViewModel GetElement(int id)
        {
            Payment element = source.Payments.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new PaymentViewModel
                {
                    Id = element.Id,
                    PaymentName = element.PaymentName
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(PaymentBindingModel model)
        {
            Payment element = source.Payments.FirstOrDefault(rec => rec.PaymentName == model.PaymentName);
            if (element != null)
            {
                throw new Exception("Уже есть выплата с таким названием");
            }
            int maxId = source.Payments.Count > 0 ? source.Payments.Max(rec => rec.Id) : 0;
            source.Payments.Add(new Payment
            {
                Id = maxId + 1,
                PaymentName = model.PaymentName
            });
        }

        public void UpdElement(PaymentBindingModel model)
        {
            Payment element = source.Payments.FirstOrDefault(rec =>
                                        rec.PaymentName == model.PaymentName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть выплата с таким названием");
            }
            element = source.Payments.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.PaymentName = model.PaymentName;
        }

        public void DelElement(int id)
        {
            Payment element = source.Payments.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.Payments.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}