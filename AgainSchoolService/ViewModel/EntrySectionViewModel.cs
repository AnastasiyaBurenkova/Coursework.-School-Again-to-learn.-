using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgainSchoolService.ViewModel
{
    public class EntrySectionViewModel
    {
        public int Id { get; set; }

        public int EntryId { get; set; }

        public int SectionId { get; set; }

        public string SectionName { get; set; }

        public decimal SectionPrice { get; set; }
    }
}
