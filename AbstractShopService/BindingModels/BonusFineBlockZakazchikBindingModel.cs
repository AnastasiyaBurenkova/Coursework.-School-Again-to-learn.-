using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AbstractShopService.BindingModels
{
    [DataContract]
    public class BonusFineBlockZakazchikBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int BonusFineBlockId { get; set; }
        [DataMember]
        public int ZakazchikId { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
