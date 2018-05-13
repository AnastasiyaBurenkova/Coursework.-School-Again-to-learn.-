using AbstractShopService.BindingModels;
using AbstractShopService.ViewModels;
using System.Collections.Generic;

namespace AbstractShopService.Interfaces
{
    public interface ISectionService
    {
        List<SectionViewModel> GetList();

        SectionViewModel GetElement(int id);

        void AddElement(SectionBindingModel model);

        void UpdElement(SectionBindingModel model);

        void DelElement(int id);
    }
}
