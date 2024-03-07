using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC2_CodeFirst_IBelmonte_PBesalú.Entities
{
    [Table("Payments")]
    public class Payments : DbContext
    {
        [ForeignKey("Customers")]
        [Column(TypeName = "int(11)")]
        public int CustomerNumber { get; set; }

        public Customers Customers { get; set; }

        [StringLength(50)]
        public string CheckNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime PaymentDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public double Amount { get; set; }
    }
}
