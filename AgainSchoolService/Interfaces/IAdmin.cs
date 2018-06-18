using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgainSchoolService.BindingModel;
using AgainSchoolService.ViewModel;

namespace AgainSchoolService.Interfaces
{
    public interface IAdmin
    {
        List<AdminViewModel> GetList();

        AdminViewModel GetElement(int id);

        void AddElement(AdminBindingModel model);

        void UpdElement(AdminBindingModel model);

        void DelElement(int id);
    }
}