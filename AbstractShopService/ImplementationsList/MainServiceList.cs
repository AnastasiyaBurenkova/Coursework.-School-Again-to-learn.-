using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;

namespace AbstractShopService.ImplementationsList
{
    public class MainServiceList : IMainService
    {
        private DataListSingleton source;

        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<EntryViewModel> GetList()
        {
            List<EntryViewModel> result = new List<EntryViewModel>();
            for (int i = 0; i < source.Entrys.Count; ++i)
            {
                string ClientFIO = string.Empty;
                for (int j = 0; j < source.Clients.Count; ++j)
                {
                    if (source.Clients[j].Id == source.Entrys[i].ClientId)
                    {
                        ClientFIO = source.Clients[j].ClientFIO;
                        break;
                    }
                }
                string SectionTip = string.Empty;
                string SectionPrepod = string.Empty;
                for (int j = 0; j < source.Sections.Count; ++j)
                {
                    if (source.Sections[j].Id == source.Entrys[i].SectionId)
                    {
                        SectionTip = source.Sections[j].SectionName;
                        SectionPrepod = source.Sections[j].PrepodName;
                        break;
                    }
                }
               
                result.Add(new EntryViewModel
                {
                    Id = source.Entrys[i].Id,
                    ClientId = source.Entrys[i].ClientId,
                    ClientFIO = ClientFIO,
                    SectionId = source.Entrys[i].SectionId,
                    SectionName = SectionTip,
                    PrepodName = SectionPrepod,
                    Sum = source.Entrys[i].Sum,
                    DateCreate = source.Entrys[i].DateCreate.ToLongDateString(),
                    DateImplement = source.Entrys[i].DateImplement?.ToLongDateString(),
                    Status = source.Entrys[i].Status.ToString()
                });
            }
            return result;
        }

        public void CreateEntry(EntryBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Entrys.Count; ++i)
            {
                if (source.Entrys[i].Id > maxId)
                {
                    maxId = source.Clients[i].Id;
                }
            }
            source.Entrys.Add(new Entry
            {
                Id = maxId + 1,
                ClientId = model.ClientId,
                SectionId = model.SectionId,
                DateCreate = DateTime.Now,
               
                Sum = model.Sum,
                Status = PaymentStatus.Неоплачен
            });
        }

       

        public void FinishEntry(int id)
        {
            int index = -1;
            for (int i = 0; i < source.Entrys.Count; ++i)
            {
                if (source.Clients[i].Id == id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Entrys[index].Status = PaymentStatus.Оплачен;
        }

        

        public void PutClientOnBonusFineBlock(ClientBonusFineBlockBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.ClientBonusFineBlocks.Count; ++i)
            {
                if (source.ClientBonusFineBlocks[i].BonusFineBlockId == model.BonusFineBlockId &&
                    source.ClientBonusFineBlocks[i].ClientId == model.ClientId)
                {
                    source.ClientBonusFineBlocks[i].Sum += model.Sum;
                    return;
                }
                if (source.ClientBonusFineBlocks[i].Id > maxId)
                {
                    maxId = source.ClientBonusFineBlocks[i].Id;
                }
            }
            source.ClientBonusFineBlocks.Add(new ClientBonusFineBlock
            {
                Id = ++maxId,
                BonusFineBlockId = model.BonusFineBlockId,
                ClientId = model.ClientId,
               Sum = model.Sum
            });
        }
    }
}
