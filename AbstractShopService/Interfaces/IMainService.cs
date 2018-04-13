using AbstractShopService.BindingModels;
using AbstractShopService.ViewModels;
using System.Collections.Generic;

namespace AbstractShopService.Interfaces
{
    public interface IMainService
    {
        List<EntryViewModel> GetList();

        void CreateEntry(EntryBindingModel model);

        void FinishEntry(int id);

        void PutClientOnBonusFineBlock(ClientBonusFineBlockBindingModel model);
    }
}
