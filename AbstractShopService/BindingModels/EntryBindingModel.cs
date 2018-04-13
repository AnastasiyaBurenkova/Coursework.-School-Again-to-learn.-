using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShopService.BindingModels
{
    public class EntryBindingModel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int SectionId { get; set; }

        public decimal Sum { get; set; }
    }
}
