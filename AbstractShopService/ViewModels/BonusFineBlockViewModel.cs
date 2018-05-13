using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AbstractShopService.ViewModels
{
    [DataContract]
    public class BonusFineBlockViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string BonusFineBlockName { get; set; }
        [DataMember]
        public List<BonusFineBlockZakazchikViewModel> BonusFineBlockPayments { get; set; }
    }
}
