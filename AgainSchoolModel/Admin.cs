using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgainSchoolModel
{
    public class Admin
    {
        public int Id { get; set; }

        [Required]
        public string AdminFIO { get; set; }

        [Required]
        public string Password { get; set; }

        [ForeignKey("AdminId")]
        public virtual List<Order> Orders { get; set; }
    }
}
