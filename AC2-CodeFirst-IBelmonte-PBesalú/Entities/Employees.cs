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
    public class Employees
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int EmployeeNumber { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string Extension { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [ForeignKey("OfficeCode")]
        [StringLength(50)]
        public string OfficeCode { get; set; }

        public Offices Offices { get; set; }

        [ForeignKey("Customers")]
        [Column(TypeName = "int(11)")]
        public int ReportsTo { get; set; }

        [StringLength(50)]
        public string JobTitle { get; set; }
    }
}
