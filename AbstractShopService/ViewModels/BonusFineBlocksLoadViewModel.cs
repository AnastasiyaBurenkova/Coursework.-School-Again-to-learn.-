using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AbstractShopService.ViewModels
{
    [DataContract]
    public class BonusFineBlocksLoadViewModel
    {
        [DataMember]
        public string BonusFineBlockName { get; set; }
        [DataMember]
        public int TotalCount { get; set; }
        [DataMember]
        public List<BonusFineBlocksPaymentLoadViewModel> Components { get; set; }
    }

    [DataContract]
    public class BonusFineBlocksPaymentLoadViewModel
    {
        [DataMember]
        public string PaymentName { get; set; }

        [DataMember]
        public int Count { get; set; }
}
}
