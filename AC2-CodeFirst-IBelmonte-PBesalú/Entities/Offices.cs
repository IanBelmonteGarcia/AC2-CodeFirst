using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC2_CodeFirst_IBelmonte_PBesalú.Entities
{
    [Table("Offices")]
    public class Offices
    {
        [Key]
        [StringLength(10)]
        public string OfficeCode { get; set; }

        [StringLength(10)]
        public string City { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [StringLength(10)]
        public string AddressLine1 { get; set; }

        [StringLength(10)]
        public string AddressLine2 { get; set; }

        [StringLength(10)]
        public string State { get; set; }

        [StringLength(10)]
        public string Country { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(10)]
        public string Territory { get; set; }
    }
}
