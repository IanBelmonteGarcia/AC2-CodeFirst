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
    [Table("OrderDetails")]
    public class OrderDetails : DbContext
    {
        [ForeignKey("Orders")]
        [Column(TypeName = "int(11)")]
        public int OrderNumber { get; set; }

        [ForeignKey("Products")]
        [StringLength(50)]
        public string ProductCode { get; set; }

        [Column(TypeName = "int(11)")]
        public int QuantityOrdered { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public double PriceEach { get; set; }

        [Column(TypeName = "int(11)")]
        public int OrderLineNumber { get; set; }
    }
}
