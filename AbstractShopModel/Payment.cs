using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AbstractShopModel
{
    /// <summary>
    /// Выплаты, требуемые для создания кружка
    /// </summary>
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public string PaymentName { get; set; }
        [ForeignKey("PaymentId")]
       public virtual List<SectionPayment> SectionPayments { get; set; }

    }
}
