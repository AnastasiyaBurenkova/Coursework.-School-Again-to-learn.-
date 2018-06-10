using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgainSchoolService.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public string ClientFIO { get; set; }

        public int EntryId { get; set; }

        public string EntryName { get; set; }

        public int? AdminId { get; set; }

        public string AdminName { get; set; }

        public int Hour { get; set; }

        public decimal Summa { get; set; }

        public decimal Oplata { get; set; }

        public int BonusFine { get; set; }

        public string Status { get; set; }
      
        public string DateOfCreate { get; set; }

        public string DateOfImplement { get; set; }
    }
}
