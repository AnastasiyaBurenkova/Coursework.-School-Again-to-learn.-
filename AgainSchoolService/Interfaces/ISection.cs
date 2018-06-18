using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgainSchoolService.BindingModel;
using AgainSchoolService.ViewModel;

namespace AgainSchoolService.Interfaces
{
    public interface ISection
    {
        List<SectionViewModel> GetList();

        SectionViewModel GetElement(int id);

        void AddElement(SectionBindingModel model);

        void UpdElement(SectionBindingModel model);

        void DelElement(int id);
    }
}

