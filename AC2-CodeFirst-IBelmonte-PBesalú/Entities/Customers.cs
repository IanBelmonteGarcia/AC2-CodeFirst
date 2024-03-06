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
        public int CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactFirstName { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        [ForeignKey("Employees")]
        public int SalesRepEmployeeNumber { get; set; }
        public Employees Employees { get; set; }
        public double CreditLimit { get; set; }
    }
}
