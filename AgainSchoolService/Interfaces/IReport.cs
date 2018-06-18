using AgainSchoolService.BindingModel;
using AgainSchoolService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgainSchoolService.Interfaces
{
   public interface IReport
    {
        void SaveSectionPriceW(ReportBindingModel model);

        void SaveSectionPriceE(ReportBindingModel model);

        List<ClientOrdersViewModel> GetClientOrders(int id, ReportBindingModel model);

        void SaveClientOrders(int id, ReportBindingModel model);

        void SaveEntryPriceW(ReportBindingModel model);

        void SaveEntryPriceE(ReportBindingModel model);

        List<ClientOrdersViewModel> GetClientOrders(ReportBindingModel model);

        void SaveClientOrders(ReportBindingModel model);


    }
}
