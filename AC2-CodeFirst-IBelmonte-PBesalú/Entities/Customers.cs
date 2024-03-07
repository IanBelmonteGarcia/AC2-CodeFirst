using AC2_CodeFirst_IBelmonte_PBesalú.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC2_CodeFirst_IBelmonte_PBesalú
{
    [Table("Customers")]
    public class Customers
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int CustomerNumber { get; set; }
        
        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string ContactLastName { get; set; }

        [StringLength(50)]
        public string ContactFirstName { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string AddressLine1 { get; set; }

        [StringLength(50)]
        public string AddressLine2 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string PostalCode { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [Column(TypeName = "int(11)")]
        public int SalesRepEmployeeNumber { get; set; }

        public Employees Employees { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal CreditLimit { get; set; }
    }
}
