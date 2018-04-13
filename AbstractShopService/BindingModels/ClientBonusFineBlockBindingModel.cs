using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShopService.BindingModels
{
    public class ClientBonusFineBlockBindingModel
    {
        public int Id { get; set; }

        public int BonusFineBlockId { get; set; }

        public int ClientId { get; set; }

        public int Sum { get; set; }
    }
}
