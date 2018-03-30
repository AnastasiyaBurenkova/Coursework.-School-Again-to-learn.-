using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;

namespace AbstractShopService.ImplementationsList
{
    public class BonusFineBlockServiceList : IBonusFineBlockService
    {
        private DataListSingleton source;

        public BonusFineBlockServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<BonusFineBlockViewModel> GetList()
        {
            List<BonusFineBlockViewModel> result = new List<BonusFineBlockViewModel>();
            for (int i = 0; i < source.BonusFineBlocks.Count; ++i)
            {
                List<ClientBonusFineBlockViewModel> ClientBonusFineBlocks = new List<ClientBonusFineBlockViewModel>();
                for (int j = 0; j < source.ClientBonusFineBlocks.Count; ++j)
                {
                    if (source.ClientBonusFineBlocks[j].BonusFineBlockId == source.BonusFineBlocks[i].Id)
                    {
                        string ClientFIO = string.Empty;
                        
                        ClientBonusFineBlocks.Add(new ClientBonusFineBlockViewModel
                        {
                            Id = source.ClientBonusFineBlocks[j].Id,
                            BonusFineBlockId = source.ClientBonusFineBlocks[j].BonusFineBlockId,
                            ClientId = source.ClientBonusFineBlocks[j].ClientId,
                            ClientName = ClientFIO
                        });
                    }
                }
                result.Add(new BonusFineBlockViewModel
                {
                    Id = source.BonusFineBlocks[i].Id,
                    BonusFineBlockName = source.BonusFineBlocks[i].BonusFineBlockName,
                    ClientBonusFineBlocks = ClientBonusFineBlocks
                });
            }
            return result;
        }

        public BonusFineBlockViewModel GetElement(int id)
        {
            for (int i = 0; i < source.BonusFineBlocks.Count; ++i)
            {
                List<ClientBonusFineBlockViewModel> ClientBonusFineBlocks = new List<ClientBonusFineBlockViewModel>();
                for (int j = 0; j < source.ClientBonusFineBlocks.Count; ++j)
                {
                    if (source.ClientBonusFineBlocks[j].BonusFineBlockId == source.BonusFineBlocks[i].Id)
                    {
                        string ClientFIO = string.Empty;
                       
                        ClientBonusFineBlocks.Add(new ClientBonusFineBlockViewModel
                        {
                            Id = source.ClientBonusFineBlocks[j].Id,
                            BonusFineBlockId = source.ClientBonusFineBlocks[j].BonusFineBlockId,
                            ClientId = source.ClientBonusFineBlocks[j].ClientId,
                            ClientName = ClientFIO
                        });
                    }
                }
                if (source.BonusFineBlocks[i].Id == id)
                {
                    return new BonusFineBlockViewModel
                    {
                        Id = source.BonusFineBlocks[i].Id,
                        BonusFineBlockName = source.BonusFineBlocks[i].BonusFineBlockName,
                        ClientBonusFineBlocks = ClientBonusFineBlocks
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(BonusFineBlockBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.BonusFineBlocks.Count; ++i)
            {
                if (source.BonusFineBlocks[i].Id > maxId)
                {
                    maxId = source.BonusFineBlocks[i].Id;
                }
                if (source.BonusFineBlocks[i].BonusFineBlockName == model.BonusFineBlockName)
                {
                    throw new Exception("Уже есть бонус или штраф с таким названием");
                }
            }
            source.BonusFineBlocks.Add(new BonusFineBlock
            {
                Id = maxId + 1,
                BonusFineBlockName = model.BonusFineBlockName
            });
        }

        public void UpdElement(BonusFineBlockBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.BonusFineBlocks.Count; ++i)
            {
                if (source.BonusFineBlocks[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.BonusFineBlocks[i].BonusFineBlockName == model.BonusFineBlockName &&
                    source.BonusFineBlocks[i].Id != model.Id)
                {
                    throw new Exception("Уже есть бонус или штраф с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.BonusFineBlocks[index].BonusFineBlockName = model.BonusFineBlockName;
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.ClientBonusFineBlocks.Count; ++i)
            {
                if (source.ClientBonusFineBlocks[i].BonusFineBlockId == id)
                {
                    source.ClientBonusFineBlocks.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.BonusFineBlocks.Count; ++i)
            {
                if (source.BonusFineBlocks[i].Id == id)
                {
                    source.BonusFineBlocks.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
