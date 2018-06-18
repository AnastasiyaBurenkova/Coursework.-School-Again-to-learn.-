using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AgainSchoolModel
{
    [DataContract]
    public class EntrySection
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int EntryId { get; set; }
        [DataMember]
        public int SectionId { get; set; }
        [DataMember]
        public decimal SectionPrice { get; set; }

        public virtual Entry Entry { get; set; }

        public virtual Section Section { get; set; }
    }
}