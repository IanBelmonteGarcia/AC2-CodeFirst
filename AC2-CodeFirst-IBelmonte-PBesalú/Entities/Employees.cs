using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC2_CodeFirst_IBelmonte_PBesalú.Entities
{
    [Table("Employees")]
    class Employees
    {
        [Key]
        public int EmployeeNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Extension { get; set; }
        public string Email { get; set; }
        [ForeignKey("OfficeCode")]
        public string OfficeCode { get; set; }
        public Offices Offices { get; set; }
        [ForeignKey("Customers")]
        public int ReportsTo { get; set; }
        public string JobTitle { get; set; }
    }
}
