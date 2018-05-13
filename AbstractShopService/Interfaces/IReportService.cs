using AbstractShopService.BindingModels;
using AbstractShopService.ViewModels;
using System.Collections.Generic;

namespace AbstractShopService.Interfaces
{
    public interface IReportService
    {
        void SaveSectionPrice(ReportBindingModel model);

        List<BonusFineBlocksLoadViewModel> GetBonusFineBlocksLoad();

        void SaveBonusFineBlocksLoad(ReportBindingModel model);

        List<ZakazchikZakazsModel> GetZakazchikZakazs(ReportBindingModel model);

        void SaveZakazchikZakazs(ReportBindingModel model);
    }
}
