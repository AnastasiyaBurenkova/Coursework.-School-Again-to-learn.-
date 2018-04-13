using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShopService.ViewModels
{
    public class BonusFineBlockViewModel
    {
        public int Id { get; set; }

        public string BonusFineBlockName { get; set; }

        public List<ClientBonusFineBlockViewModel> ClientBonusFineBlocks { get; set; }
    }
}
