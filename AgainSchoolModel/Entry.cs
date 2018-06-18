using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AgainSchoolModel
{
    [DataContract]
    public class Entry
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string EntryName { get; set; }
        [DataMember]
        [Required]
        public decimal Price { get; set; }

        [ForeignKey("EntryId")]
        public virtual List<Order> Orders { get; set; }

        [ForeignKey("EntryId")]
        public virtual List<EntrySection> EntrySections { get; set; }
    }
}
