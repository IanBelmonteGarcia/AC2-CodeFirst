using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AC2_CodeFirst_IBelmonte_PBesalú.Entities
{
    public class DbContextIBPB : DbContext
    {
        public DbContextIBPB() {}
        public DbContextIBPB(DbContextOptions<DbContextIBPB> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=SHOP;Uid=root;Pwd=;",
                    ServerVersion.AutoDetect("Server=localhost;Database=SHOP;Uid=root;Pwd=;"));

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>().HasKey(p => new { p.OrderNumber, p.ProductCode });
            modelBuilder.Entity<Payments>().HasKey(p => new { p.CustomerNumber, p.CheckNumber });
        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Offices> Offices { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<ProductLines> ProductLines { get; set; }
        public DbSet<Products> Products { get; set; }

    }
}
