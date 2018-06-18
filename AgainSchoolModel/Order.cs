using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AgainSchoolModel
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int EntryId { get; set; }
        [DataMember]
        public int? AdminId { get; set; }
        [DataMember]
        public int Hour { get; set; }
        [DataMember]
        public decimal Summa { get; set; }
        [DataMember]
        public decimal Oplata { get; set; }
        [DataMember]
        public int BonusFine { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public DateTime DateOfCreate { get; set; }
        [DataMember]
        public DateTime? DateOfImplement { get; set; }
        [DataMember]
        public virtual Client Client { get; set; }
        [DataMember]
        public virtual Entry Entry { get; set; }
        [DataMember]
        public virtual Admin Admin { get; set; }
    }
}