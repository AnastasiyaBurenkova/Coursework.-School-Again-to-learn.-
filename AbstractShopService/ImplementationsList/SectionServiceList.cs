using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;

namespace AbstractShopService.ImplementationsList
{
    public class SectionServiceList : ISectionService
    {
        private DataListSingleton source;

        public SectionServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<SectionViewModel> GetList()
        {
            List<SectionViewModel> result = new List<SectionViewModel>();
            for (int i = 0; i < source.Sections.Count; ++i)
            {
                
                result.Add(new SectionViewModel
                {
                    Id = source.Sections[i].Id,
                    SectionName = source.Sections[i].SectionName,
                    PrepodName  = source.Sections[i].PrepodName,
                    Price = source.Sections[i].Price
                });
            }
            return result;
        }

        public SectionViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Sections.Count; ++i)
            {
               
                if (source.Sections[i].Id == id)
                {
                    return new SectionViewModel
                    {
                        Id = source.Sections[i].Id,
                        SectionName = source.Sections[i].SectionName,
                        PrepodName = source.Sections[i].PrepodName,
                        Price = source.Sections[i].Price                     
                    };
                }
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElement(SectionBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Sections.Count; ++i)
            {
                if (source.Sections[i].Id > maxId)
                {
                    maxId = source.Sections[i].Id;
                }
                if (source.Sections[i].SectionName == model.SectionName)
                {
                    throw new Exception("Уже есть кружок с таким названием");
                }
            }
            source.Sections.Add(new Section
            {
                Id = maxId + 1,
                SectionName = model.SectionName,
                PrepodName = model.PrepodName,
                Price = model.Price
            });
            
        }

        public void UpdElement(SectionBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Sections.Count; ++i)
            {
                if (source.Sections[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Sections[i].SectionName == model.SectionName &&
                    source.Sections[i].Id != model.Id)
                {
                    throw new Exception("Уже есть кружок с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Sections[index].SectionName = model.SectionName;
            source.Sections[index].PrepodName = model.PrepodName;
            source.Sections[index].Price = model.Price;
        }  
           
        public void DelElement(int id)
        {
           for (int i = 0; i < source.Sections.Count; ++i)
            {
                if (source.Sections[i].Id == id)
                {
                    source.Sections.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}

