using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AgainSchoolModel
{
    [DataContract]
    public class Admin
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string AdminFIO { get; set; }
        [DataMember]
        [Required]
        public string Password { get; set; }

        [ForeignKey("AdminId")]
        public virtual List<Order> Orders { get; set; }
    }
}
