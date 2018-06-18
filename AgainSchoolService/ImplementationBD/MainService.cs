using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgainSchoolModel;
using AgainSchoolService.BindingModel;
using AgainSchoolService.Interfaces;
using AgainSchoolService.ViewModel;

namespace AgainSchoolService.ImplementationBD
{
    public class MainService : IMain
    {
        private AgSchoolDbContext context;

        public MainService(AgSchoolDbContext context)
        {
            this.context = context;
        }

        public OrderViewModel GetElement(int id)
        {
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new OrderViewModel
                {
                    Id = element.Id,
                    ClientId = element.ClientId,                                
                    Status = element.Status,                 
                    Summa = element.Summa,
                    Oplata = element.Oplata,
                    BonusFine = element.BonusFine,

                };
            }
            throw new Exception("Элемент не найден");
        }

        public List<OrderViewModel> GetList(int id)
        {
            List<OrderViewModel> result = context.Orders
                .Where(rec => rec.Client.Id == id)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ClientId = rec.ClientId,
                    EntryId = rec.EntryId,
                    AdminId = rec.AdminId,
                    DateOfCreate = SqlFunctions.DateName("dd", rec.DateOfCreate) + " " +
                                SqlFunctions.DateName("mm", rec.DateOfCreate) + " " +
                                SqlFunctions.DateName("yyyy", rec.DateOfCreate),
                    DateOfImplement = rec.DateOfImplement == null ? "" :
                                        SqlFunctions.DateName("dd", rec.DateOfImplement.Value) + " " +
                                        SqlFunctions.DateName("mm", rec.DateOfImplement.Value) + " " +
                                        SqlFunctions.DateName("yyyy", rec.DateOfImplement.Value),
                    Status = rec.Status,
                    Hour = rec.Hour,
                    Summa = rec.Summa,
                    Oplata = rec.Oplata,
                    BonusFine = rec.BonusFine,
                    ClientFIO = rec.Client.ClientFIO,
                    EntryName = rec.Entry.EntryName,
                    AdminName = rec.Admin.AdminFIO
                })
                .ToList();
            return result;
        }

        public List<OrderViewModel> GetList()
        {
            List<OrderViewModel> result = context.Orders              
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ClientId = rec.ClientId,
                    EntryId = rec.EntryId,
                    AdminId = rec.AdminId,
                    DateOfCreate = SqlFunctions.DateName("dd", rec.DateOfCreate) + " " +
                                SqlFunctions.DateName("mm", rec.DateOfCreate) + " " +
                                SqlFunctions.DateName("yyyy", rec.DateOfCreate),
                    DateOfImplement = rec.DateOfImplement == null ? "" :
                                        SqlFunctions.DateName("dd", rec.DateOfImplement.Value) + " " +
                                        SqlFunctions.DateName("mm", rec.DateOfImplement.Value) + " " +
                                        SqlFunctions.DateName("yyyy", rec.DateOfImplement.Value),
                    Status = rec.Status,
                    Hour = rec.Hour,
                    Summa = rec.Summa,
                    Oplata = rec.Oplata,
                    BonusFine = rec.BonusFine,
                    ClientFIO = rec.Client.ClientFIO,
                    EntryName = rec.Entry.EntryName,
                    AdminName = rec.Admin.AdminFIO
                })
                .ToList();
            return result;
        }

        public void CreateOrder(OrderBindingModel model)
        {
            context.Orders.Add(new Order
            {
                ClientId = model.ClientId,
                EntryId = model.EntryId,
                DateOfCreate = DateTime.Now,
                Hour = model.Hour,
                Summa = model.Summa,
                Status = model.Status
            });
            context.SaveChanges();
        }
    
        public void PayOrder(OrderBindingModel model)
        {           
                try
                {
                    Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.Oplata = model.Oplata;
                    element.Status = model.Status;
                    element.DateOfImplement = DateTime.Now;
                    context.SaveChanges();
            }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        public void BonusFineOrder(OrderBindingModel model)
        {
            try
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                element.BonusFine = model.BonusFine;
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateOrder(OrderBindingModel model)
        {
            try
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                element.Summa = model.Summa;
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

