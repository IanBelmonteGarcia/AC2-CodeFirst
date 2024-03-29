﻿// <auto-generated />
using System;
using AC2_CodeFirst_IBelmonte_PBesalú.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AC2_CodeFirst_IBelmonte_PBesalú.Migrations
{
    [DbContext(typeof(DbContextIBPB))]
    [Migration("20240307130248_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AC2_CodeFirst_IBelmonte_PBesalú.Customers", b =>
                {
                    b.Property<int>("CustomerNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ContactFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ContactLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("CreditLimit")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("EmployeesEmployeeNumber")
                        .HasColumnType("int(11)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("SalesRepEmployeeNumber")
                        .HasColumnType("int(11)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("CustomerNumber");

                    b.HasIndex("EmployeesEmployeeNumber");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AC2_CodeFirst_IBelmonte_PBesalú.Entities.Employees", b =>
                {
                    b.Property<int>("EmployeeNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("OfficeCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("OfficesOfficeCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<int>("ReportsTo")
                        .HasColumnType("int(11)");

                    b.HasKey("EmployeeNumber");

                    b.HasIndex("OfficesOfficeCode");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AC2_CodeFirst_IBelmonte_PBesalú.Entities.Offices", b =>
                {
                    b.Property<string>("OfficeCode")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Territory")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("OfficeCode");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("AC2_CodeFirst_IBelmonte_PBesalú.Entities.OrderDetails", b =>
                {
                    b.Property<int>("OrderNumber")
                        .HasColumnType("int(11)");

                    b.Property<string>("ProductCode")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("OrderLineNumber")
                        .HasColumnType("int(11)");

                    b.Property<decimal>("PriceEach")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("QuantityOrdered")
                        .HasColumnType("int(11)");

                    b.HasKey("OrderNumber", "ProductCode");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("AC2_CodeFirst_IBelmonte_PBesalú.Entities.Orders", b =>
                {
                    b.Property<int>("OrderNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("CustomerNumber")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("RequiredDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("ShippedDate")
                        .HasColumnType("date");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("OrderNumber");

                    b.HasIndex("CustomerNumber");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("AC2_CodeFirst_IBelmonte_PBesalú.Entities.Payments", b =>
                {
                    b.Property<int>("CustomerNumber")
                        .HasColumnType("int(11)");

                    b.Property<string>("CheckNumber")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("date");

                    b.HasKey("CustomerNumber", "CheckNumber");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("AC2_CodeFirst_IBelmonte_PBesalú.Entities.ProductLines", b =>
                {
                    b.Property<string>("ProductLine")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("HtmlDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TextDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ProductLine");

                    b.ToTable("ProductLines");
                });

            modelBuilder.Entity("AC2_CodeFirst_IBelmonte_PBesalú.Entities.Products", b =>
                {
                    b.Property<string>("ProductCode")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("BuyPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("MSRP")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ProductLine1")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ProductLines")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ProductScale")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ProductVendor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int(11)");

                    b.HasKey("ProductCode");

                    b.HasIndex("ProductLine1");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AC2_CodeFirst_IBelmonte_PBesalú.Customers", b =>
                {
                    b.HasOne("AC2_CodeFirst_IBelmonte_PBesalú.Entities.Employees", "Employees")
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("AC2_CodeFirst_IBelmonte_PBesalú.Entities.Employees", b =>
                {
                    b.HasOne("AC2_CodeFirst_IBelmonte_PBesalú.Entities.Offices", "Offices")
                        .WithMany()
                        .HasForeignKey("OfficesOfficeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Offices");
                });

            modelBuilder.Entity("AC2_CodeFirst_IBelmonte_PBesalú.Entities.Orders", b =>
                {
                    b.HasOne("AC2_CodeFirst_IBelmonte_PBesalú.Customers", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomerNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("AC2_CodeFirst_IBelmonte_PBesalú.Entities.Payments", b =>
                {
                    b.HasOne("AC2_CodeFirst_IBelmonte_PBesalú.Customers", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomerNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("AC2_CodeFirst_IBelmonte_PBesalú.Entities.Products", b =>
                {
                    b.HasOne("AC2_CodeFirst_IBelmonte_PBesalú.Entities.ProductLines", "ProductLine")
                        .WithMany()
                        .HasForeignKey("ProductLine1");

                    b.Navigation("ProductLine");
                });
#pragma warning restore 612, 618
        }
    }
}
