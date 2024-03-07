using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC2_CodeFirst_IBelmonte_PBesalú.Entities
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int OrderNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime RequiredDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime ShippedDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string Comments { get; set; }

        [ForeignKey("Customers")]
        [Column(TypeName = "int(11)")]
        public int CustomerNumber { get; set; }

        public Customers Customers { get; set; }
    }
}
