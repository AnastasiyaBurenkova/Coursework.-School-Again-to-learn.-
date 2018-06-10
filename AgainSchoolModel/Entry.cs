using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgainSchoolModel
{
    public class Entry
    {
        public int Id { get; set; }

        [Required]
        public string EntryName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("EntryId")]
        public virtual List<Order> Orders { get; set; }

        [ForeignKey("EntryId")]
        public virtual List<EntrySection> EntrySections { get; set; }
    }
}
