using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgainSchoolService.ViewModel
{
   public class ClientOrdersViewModel
    {
        public string ClientName { get; set; }

        public string DateOfCreate { get; set; }

        public string EntryName { get; set; }

        public int Hour { get; set; }

        public decimal Summa { get; set; }

        public string Status { get; set; }
    }
}
