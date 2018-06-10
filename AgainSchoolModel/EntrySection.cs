using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgainSchoolModel
{
    public class EntrySection
    {
        public int Id { get; set; }

        public int EntryId { get; set; }

        public int SectionId { get; set; }

        public decimal SectionPrice { get; set; }

        public virtual Entry Entry { get; set; }

        public virtual Section Section { get; set; }
    }
}