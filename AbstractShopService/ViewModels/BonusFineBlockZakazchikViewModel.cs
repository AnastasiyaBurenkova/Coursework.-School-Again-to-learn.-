using System.Runtime.Serialization;

namespace AbstractShopService.ViewModels
{
    [DataContract]
    public class BonusFineBlockZakazchikViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int BonusFineBlockId { get; set; }
        [DataMember]
        public int ZakazchikId { get; set; }
        [DataMember]
        public string ZakazchikName { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
