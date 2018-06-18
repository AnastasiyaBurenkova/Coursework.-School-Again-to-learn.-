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
    public class EntryService : IEntry
    {
        private AgSchoolDbContext context;

        public EntryService(AgSchoolDbContext context)
        {
            this.context = context;
        }

        public List<EntryViewModel> GetList()
        {
            List<EntryViewModel> result = context.Entrys
                .Select(rec => new EntryViewModel
                {
                    Id = rec.Id,
                    EntryName = rec.EntryName,
                    Price = rec.Price,
                    EntrySections = context.EntrySections
                            .Where(recPC => recPC.EntryId == rec.Id)
                            .Select(recPC => new EntrySectionViewModel
                            {
                                Id = recPC.Id,
                                EntryId = recPC.EntryId,
                                SectionId = recPC.SectionId,
                                SectionName = recPC.Section.SectionName,
                                SectionPrice = recPC.SectionPrice
                            })
                            .ToList()
                })
                .ToList();
            return result;
        }

        public EntryViewModel GetElement(int id)
        {
            Entry element = context.Entrys.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new EntryViewModel
                {
                    Id = element.Id,
                    EntryName = element.EntryName,
                    Price = element.Price,
                    EntrySections = context.EntrySections
                            .Where(recPC => recPC.EntryId == element.Id)
                            .Select(recPC => new EntrySectionViewModel
                            {
                                Id = recPC.Id,
                                EntryId = recPC.EntryId,
                                SectionId = recPC.SectionId,
                                SectionName = recPC.Section.SectionName,
                                SectionPrice = recPC.SectionPrice
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(EntryBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Entry element = context.Entrys.FirstOrDefault(rec => rec.EntryName == model.EntryName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть кружок с таким названием");
                    }
                    element = new Entry
                    {
                        EntryName = model.EntryName,
                        Price = model.Price
                    };
                    context.Entrys.Add(element);
                    context.SaveChanges();
                    var groupComponents = model.EntrySections
                                                .GroupBy(rec => rec.SectionId)
                                                .Select(rec => new
                                                {
                                                    ComponentId = rec.Key,
                                                    Count = rec.Sum(r => r.SectionPrice)
                                                });
                    foreach (var groupComponent in groupComponents)
                    {
                        context.EntrySections.Add(new EntrySection
                        {
                            EntryId = element.Id,
                            SectionId = groupComponent.ComponentId,
                            SectionPrice = groupComponent.Count
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void UpdElement(EntryBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Entry element = context.Entrys.FirstOrDefault(rec =>
                                        rec.EntryName == model.EntryName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть кружок с таким названием");
                    }
                    element = context.Entrys.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.EntryName = model.EntryName;
                    element.Price = model.Price;
                    context.SaveChanges();

                    var compIds = model.EntrySections.Select(rec => rec.SectionId).Distinct();
                    var updateComponents = context.EntrySections
                                                    .Where(rec => rec.EntryId == model.Id &&
                                                        compIds.Contains(rec.SectionId));
                    foreach (var updateComponent in updateComponents)
                    {
                        updateComponent.SectionPrice = model.EntrySections
                                                        .FirstOrDefault(rec => rec.Id == updateComponent.Id).SectionPrice;
                    }
                    context.SaveChanges();
                    context.EntrySections.RemoveRange(
                                        context.EntrySections.Where(rec => rec.EntryId == model.Id &&
                                                                            !compIds.Contains(rec.SectionId)));
                    context.SaveChanges();
                    var groupComponents = model.EntrySections
                                                .Where(rec => rec.Id == 0)
                                                .GroupBy(rec => rec.SectionId)
                                                .Select(rec => new
                                                {
                                                    ComponentId = rec.Key,
                                                    Count = rec.Sum(r => r.SectionPrice)
                                                });
                    foreach (var groupComponent in groupComponents)
                    {
                        EntrySection elementPC = context.EntrySections
                                                .FirstOrDefault(rec => rec.EntryId == model.Id &&
                                                                rec.SectionId == groupComponent.ComponentId);
                        if (elementPC != null)
                        {
                            elementPC.SectionPrice += groupComponent.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.EntrySections.Add(new EntrySection
                            {
                                EntryId = model.Id,
                                SectionId = groupComponent.ComponentId,
                                SectionPrice = groupComponent.Count
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Entry element = context.Entrys.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        context.EntrySections.RemoveRange(
                                            context.EntrySections.Where(rec => rec.EntryId == id));
                        context.Entrys.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
