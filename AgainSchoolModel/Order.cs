using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgainSchoolModel
{
    public class Order
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int EntryId { get; set; }

        public int? AdminId { get; set; }

        public int Hour { get; set; }

        public decimal Summa { get; set; }

        public decimal Oplata { get; set; }

        public int BonusFine { get; set; }

        public string Status { get; set; }

        public DateTime DateOfCreate { get; set; }

        public DateTime? DateOfImplement { get; set; }

        public virtual Client Client { get; set; }

        public virtual Entry Entry { get; set; }

        public virtual Admin Admin { get; set; }
    }
}