using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShopModel
{
    public class BonusFineBlockZakazchik
    {
        public int Id { get; set; }

        public int BonusFineBlockId { get; set; }

        public int ZakazchikId { get; set; }

        public int Count { get; set; }
        public virtual BonusFineBlock BonusFineBlock { get; set; }

        public virtual Zakazchik Zakazchik { get; set; }
    }
}
