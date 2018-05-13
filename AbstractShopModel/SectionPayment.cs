using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShopModel
{
    /// <summary>
    /// Сколько выплат производится в один кружок
    /// </summary>
    public class SectionPayment
    {
        public int Id { get; set; }

        public int SectionId { get; set; }

        public int PaymentId { get; set; }

        public int Count { get; set; }
        public virtual Section Section { get; set; }

       public virtual Payment Payment { get; set; }
    }
}