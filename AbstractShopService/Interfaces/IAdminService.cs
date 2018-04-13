using AbstractShopService.BindingModels;
using AbstractShopService.ViewModels;
using System.Collections.Generic;

namespace AbstractShopService.Interfaces
{
    public interface IAdminService
    {
        List<AdminViewModel> GetList();

        AdminViewModel GetElement(int id);

        void AddElement(AdminBindingModel model);

        void UpdElement(AdminBindingModel model);

        void DelElement(int id);
    }
}
