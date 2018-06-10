using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgainSchoolService.BindingModel;
using AgainSchoolService.ViewModel;

namespace AgainSchoolService.Interfaces
{
    public interface IEntry
    {
        List<EntryViewModel> GetList();

        EntryViewModel GetElement(int id);

        void AddElement(EntryBindingModel model);

        void UpdElement(EntryBindingModel model);

        void DelElement(int id);
    }
}
