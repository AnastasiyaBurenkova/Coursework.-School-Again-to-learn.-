using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AbstractShopService.ViewModels
{
    [DataContract]
    public class SectionViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public List<SectionPaymentViewModel> SectionPayments { get; set; }
    }
}
