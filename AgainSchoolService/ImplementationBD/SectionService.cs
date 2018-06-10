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
    public class SectionService : ISection
    {
        private AgSchoolDbContext context;

        public SectionService(AgSchoolDbContext context)
        {
            this.context = context;
        }

        public List<SectionViewModel> GetList()
        {
            List<SectionViewModel> result = context.Sections
                .Select(rec => new SectionViewModel
                {
                    Id = rec.Id,
                    SectionName = rec.SectionName,
                    PriceSection = rec.PriceSection
                })
                .ToList();
            return result;
        }

        public SectionViewModel GetElement(int id)
        {
            Section element = context.Sections.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new SectionViewModel
                {
                    Id = element.Id,
                    SectionName = element.SectionName,
                    PriceSection = element.PriceSection
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(SectionBindingModel model)
        {
            Section element = context.Sections.FirstOrDefault(rec => rec.SectionName == model.SectionName);
            if (element != null)
            {
                throw new Exception("Уже есть кружок с таким названием");
            }
            context.Sections.Add(new Section
            {
                SectionName = model.SectionName,
                PriceSection = model.PriceSection
            });
            context.SaveChanges();
        }

        public void UpdElement(SectionBindingModel model)
        {
            Section element = context.Sections.FirstOrDefault(rec =>
                                        rec.SectionName == model.SectionName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть кружок с таким названием");
            }
            element = context.Sections.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.SectionName = model.SectionName;
            element.PriceSection = model.PriceSection;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Section element = context.Sections.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Sections.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
