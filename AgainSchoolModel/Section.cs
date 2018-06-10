using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgainSchoolModel
{
    public class Section
    {
        public int Id { get; set; }

        [Required]
        public string SectionName { get; set; }

        [Required]
        public decimal PriceSection { get; set; }

        [ForeignKey("SectionId")]
        public virtual List<EntrySection> EntrySections { get; set; }
    }
}

