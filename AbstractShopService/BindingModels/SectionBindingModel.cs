using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShopService.BindingModels
{
    public class SectionBindingModel
    {
        public int Id { get; set; }

        public string SectionName { get; set; }

        public decimal Price { get; set; }
        
        public string PrepodName { get; set; }
    }
}
