using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgainSchoolService.BindingModel
{
    public class EntrySectionBindingModel
    {
        public int Id { get; set; }

        public int EntryId { get; set; }

        public int SectionId { get; set; }

        public decimal SectionPrice { get; set; }
    }
}
