using System.Runtime.Serialization;

namespace AbstractShopService.BindingModels
{
    [DataContract]
    public class PaymentBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string PaymentName { get; set; }
    }
}
