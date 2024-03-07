using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC2_CodeFirst_IBelmonte_PBesalú.Entities
{
    [Table("ProductLines")]
    public class ProductLines
    {
        [Key]
        [StringLength(50)]
        public string ProductLine { get; set; }

        [StringLength(50)]
        public string TextDescription { get; set; }

        [StringLength(50)]
        public string HtmlDescription { get; set; }

        [StringLength(50)]
        public string Image { get; set; }
    }
}
