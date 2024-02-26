using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC2_CodeFirst_IBelmonte_PBesalú.Entities
{
    [Table("OrderDetails")]
    class OrderDetails : DbContext
    {
        [ForeignKey("Orders")]
        public int OrderNumber { get; set; }
        [ForeignKey("Products")]
        public string ProductCode { get; set; }
        public int QuantityOrdered { get; set; }
        public double PriceEach { get; set; }
        public int OrderLineNumber { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>().HasKey(p => new { p.OrderNumber, p.ProductCode });
        }
    }
}
