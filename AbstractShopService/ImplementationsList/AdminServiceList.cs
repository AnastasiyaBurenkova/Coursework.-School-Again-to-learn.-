using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;

namespace AbstractShopService.ImplementationsList
{
    public class AdminServiceList : IAdminService
    {
        private DataListSingleton source;

        public AdminServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<AdminViewModel> GetList()
        {
            List<AdminViewModel> result = new List<AdminViewModel>();
            for (int i = 0; i < source.Admins.Count; ++i)
            {
                result.Add(new AdminViewModel
                {
                    Id = source.Admins[i].Id,
                    Login = source.Admins[i].Login,
                    Password = source.Admins[i].Password
                });
            }
            return result;
        }

        public AdminViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Admins.Count; ++i)
            {
                if (source.Admins[i].Id == id)
                {
                    return new AdminViewModel
                    {
                        Id = source.Admins[i].Id,
                        Login = source.Admins[i].Login,
                        Password = source.Admins[i].Password
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(AdminBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Admins.Count; ++i)
            {
                if (source.Admins[i].Id > maxId)
                {
                    maxId = source.Admins[i].Id;
                }
                if (source.Admins[i].Login == model.Login)
                {
                    throw new Exception("Уже есть сотрудник с таким ФИО");
                }
                
                    if (source.Admins[i].Password == model.Password)
                {
                    throw new Exception("Уже есть сотрудник с таким ФИО");
                }
            }
            source.Admins.Add(new Admin
            {
                Id = maxId + 1,
                Login = model.Login,
                Password=model.Password
            });
        }

        public void UpdElement(AdminBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Admins.Count; ++i)
            {
                if (source.Admins[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Admins[i].Login == model.Login &&
                    source.Admins[i].Id != model.Id)
                {
                    throw new Exception("Уже есть сотрудник с таким ФИО");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Admins[index].Login = model.Login;
            source.Admins[index].Password = model.Password;
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.Admins.Count; ++i)
            {
                if (source.Admins[i].Id == id)
                {
                    source.Admins.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
