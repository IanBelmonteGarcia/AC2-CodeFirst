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
        public int customerNumber { get; set; }
        public string customerName { get; set; }
        public string contactLastName { get; set; }
        public string contactFirstName { get; set; }
        public string phone { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        [ForeignKey("Employees")]
        public int salesRepEmployeeNumber { get; set; }
        public double creditLimit { get; set; }
    }
}
