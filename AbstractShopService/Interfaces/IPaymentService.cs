using AbstractShopService.BindingModels;
using AbstractShopService.ViewModels;
using System.Collections.Generic;

namespace AbstractShopService.Interfaces
{
    public interface IPaymentService
    {
        List<PaymentViewModel> GetList();

        PaymentViewModel GetElement(int id);

        void AddElement(PaymentBindingModel model);

        void UpdElement(PaymentBindingModel model);

        void DelElement(int id);
    }
}
