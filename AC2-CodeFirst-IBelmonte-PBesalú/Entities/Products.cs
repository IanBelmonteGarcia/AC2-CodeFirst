using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace AC2_CodeFirst_IBelmonte_PBesalú.Entities
{
    [Table("Products")]
    public class Products
    {
        [Key]
        [StringLength(50)]
        public string ProductCode { get; set; }
        
        [StringLength(50)]
        public string ProductName { get; set; }
        
        public ProductLines ProductLine { get; set; }

        [StringLength(50)]
        public string ProductLines { get; set; }

        [StringLength(50)]
        public string ProductScale { get; set; }

        [StringLength(50)]
        public string ProductVendor { get; set; }

        [StringLength(50)]
        public string ProductDescription { get; set; }

        [Column(TypeName = "int(11)")]
        public int QuantityInStock { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public double BuyPrice { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public double MSRP { get; set; }
    }
}
