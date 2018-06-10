using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgainSchoolModel;
using AgainSchoolService.BindingModel;
using AgainSchoolService.Interfaces;
using AgainSchoolService.ViewModel;

namespace AgainSchoolService.ImplementationBD
{
    public class AdminService : IAdmin
    {
        private AgSchoolDbContext context;

        public AdminService(AgSchoolDbContext context)
        {
            this.context = context;
        }

        public List<AdminViewModel> GetList()
        {
            List<AdminViewModel> result = context.Admins
                .Select(rec => new AdminViewModel
                {
                    Id = rec.Id,
                    AdminFIO = rec.AdminFIO,
                    Password = rec.Password
                })
                .ToList();
            return result;
        }

        public AdminViewModel GetElement(int id)
        {
            Admin element = context.Admins.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new AdminViewModel
                {
                    Id = element.Id,
                    AdminFIO = element.AdminFIO,
                    Password = element.Password
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(AdminBindingModel model)
        {
            Admin element = context.Admins.FirstOrDefault(rec => rec.AdminFIO == model.AdminFIO);
            if (element != null)
            {
                throw new Exception("Уже есть админисратор с таким ФИО");
            }
            context.Admins.Add(new Admin
            {
                AdminFIO = model.AdminFIO,
                Password = model.Password
            });
            context.SaveChanges();
        }

        public void UpdElement(AdminBindingModel model)
        {
            Admin element = context.Admins.FirstOrDefault(rec =>
                                        rec.AdminFIO == model.AdminFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть администратор с таким ФИО");
            }
            element = context.Admins.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.AdminFIO = model.AdminFIO;
            element.Password = model.Password;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Admin element = context.Admins.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Admins.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
