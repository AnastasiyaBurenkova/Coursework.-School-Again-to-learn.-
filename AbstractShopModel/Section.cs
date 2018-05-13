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
    /// Кружок в школе
    /// </summary>
    public class Section
    {
        public int Id { get; set; }

        [Required]
        public string SectionName { get; set; }

        [Required]
        public decimal Price { get; set; }
        [ForeignKey("SectionId")]
        public virtual List<Zakaz> Zakazs { get; set; }

        [ForeignKey("SectionId")]
        public virtual List<SectionPayment> SectionPayments { get; set; }
    }
}