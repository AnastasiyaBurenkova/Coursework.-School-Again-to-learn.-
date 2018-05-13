using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractShopModel
{
    /// <summary>
    /// бонусы, штрафы и блокировка
    /// </summary>
    public class BonusFineBlock
    {
        public int Id { get; set; }

        [Required]
        public string BonusFineBlockName { get; set; }
        [ForeignKey("BonusFineBlockId")]
        public virtual List<BonusFineBlockZakazchik> BonusFineBlockPayments { get; set; }
    }
}