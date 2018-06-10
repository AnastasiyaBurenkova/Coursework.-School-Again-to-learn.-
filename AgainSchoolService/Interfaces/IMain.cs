using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgainSchoolService.BindingModel;
using AgainSchoolService.ViewModel;

namespace AgainSchoolService.Interfaces
{
    public interface IMain
    {
        List<OrderViewModel> GetList(int id);

        List<OrderViewModel> GetList();

        void CreateOrder(OrderBindingModel model);

        void PayOrder(OrderBindingModel model);

        OrderViewModel GetElement(int id);

        void BonusFineOrder(OrderBindingModel model);

        void UpdateOrder(OrderBindingModel model);


    }
}
