using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AbstractShopService.BindingModels
{
    [DataContract]
    public class SectionPaymentBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int SectionId { get; set; }
        [DataMember]
        public int PaymentId { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
