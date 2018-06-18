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
    public class Section
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string SectionName { get; set; }
        [DataMember]
        [Required]
        public decimal PriceSection { get; set; }

        [ForeignKey("SectionId")]
        public virtual List<EntrySection> EntrySections { get; set; }
    }
}

