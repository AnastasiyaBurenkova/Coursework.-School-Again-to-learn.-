using AbstractShopService.BindingModels;
using AbstractShopService.ViewModels;
using System.Collections.Generic;

namespace AbstractShopService.Interfaces
{
    public interface IBonusFineBlockService
    {
        List<BonusFineBlockViewModel> GetList();

        BonusFineBlockViewModel GetElement(int id);

        void AddElement(BonusFineBlockBindingModel model);

        void UpdElement(BonusFineBlockBindingModel model);

        void DelElement(int id);
    }
}
