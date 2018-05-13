using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractShopService.ImplementationsBD
{
    public class PaymentServiceBD : IPaymentService
    {
        private AbstractDbContext context;

        public PaymentServiceBD(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<PaymentViewModel> GetList()
        {
            List<PaymentViewModel> result = context.Payments
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
            Payment element = context.Payments.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new PaymentViewModel
                {
                    Id = element.Id,
                    PaymentName = element.PaymentName
                };
            }
            throw new Exception("Выплата не найдена");
        }

        public void AddElement(PaymentBindingModel model)
        {
            Payment element = context.Payments.FirstOrDefault(rec => rec.PaymentName == model.PaymentName);
            if (element != null)
            {
                throw new Exception("Уже есть выплата с таким названием");
            }
            context.Payments.Add(new Payment
            {
                PaymentName = model.PaymentName
            });
            context.SaveChanges();
        }

        public void UpdElement(PaymentBindingModel model)
        {
            Payment element = context.Payments.FirstOrDefault(rec =>
                                        rec.PaymentName == model.PaymentName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть выплата с таким названием");
            }
            element = context.Payments.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Выплата не найдена");
            }
            element.PaymentName = model.PaymentName;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Payment element = context.Payments.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Payments.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Выплата не найдена");
            }
        }
    }
}
