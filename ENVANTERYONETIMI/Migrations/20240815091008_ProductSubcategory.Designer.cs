﻿// <auto-generated />
using ENVANTERYONETIMI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ENVANTERYONETIMI.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240815091008_ProductSubcategory")]
    partial class ProductSubcategory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ENVANTERYONETIMI.Models.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationID"));

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationID");

                    b.ToTable("Location", (string)null);
                });

            modelBuilder.Entity("ENVANTERYONETIMI.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<bool>("FinishedGoodsFlag")
                        .HasColumnType("bit");

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("SafetyStockLevel")
                        .HasColumnType("smallint");

                    b.Property<decimal>("StandardCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SubcategoryID")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SubcategoryID");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("ENVANTERYONETIMI.Models.ProductCategory", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("ProductCategory", (string)null);
                });

            modelBuilder.Entity("ENVANTERYONETIMI.Models.ProductInventory", b =>
                {
                    b.Property<int>("InventoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventoryID"));

                    b.Property<int>("Bin")
                        .HasColumnType("int");

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Shelf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InventoryID");

                    b.HasIndex("LocationID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductInventory", (string)null);
                });

            modelBuilder.Entity("ENVANTERYONETIMI.Models.ProductModel", b =>
                {
                    b.Property<int>("ModelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModelID"));

                    b.Property<string>("CatalogDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModelID");

                    b.ToTable("ProductModel", (string)null);
                });

            modelBuilder.Entity("ENVANTERYONETIMI.Models.ProductSubcategory", b =>
                {
                    b.Property<int>("SubcategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubcategoryID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("SubcategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubcategoryID");

                    b.HasIndex("CategoryID");

                    b.ToTable("ProductSubcategory", (string)null);
                });

            modelBuilder.Entity("ENVANTERYONETIMI.Models.PurchaseOrder", b =>
                {
                    b.Property<int>("PurchaseOrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseOrderID"));

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VendorID")
                        .HasColumnType("int");

                    b.HasKey("PurchaseOrderID");

                    b.HasIndex("VendorID");

                    b.ToTable("PurchaseOrder", (string)null);
                });

            modelBuilder.Entity("ENVANTERYONETIMI.Models.Vendor", b =>
                {
                    b.Property<int>("VendorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendorID"));

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VendorID");

                    b.ToTable("Vendor", (string)null);
                });

            modelBuilder.Entity("ENVANTERYONETIMI.Models.Product", b =>
                {
                    b.HasOne("ENVANTERYONETIMI.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ENVANTERYONETIMI.Models.ProductSubcategory", "ProductSubcategory")
                        .WithMany("Products")
                        .HasForeignKey("SubcategoryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProductCategory");

                    b.Navigation("ProductSubcategory");
                });

            modelBuilder.Entity("ENVANTERYONETIMI.Models.ProductInventory", b =>
                {
                    b.HasOne("ENVANTERYONETIMI.Models.Location", "Location")
                        .WithMany("ProductInventories")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ENVANTERYONETIMI.Models.Product", "Product")
                        .WithMany("ProductInventories")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ENVANTERYONETIMI.Models.ProductSubcategory", b =>
                {
                    b.HasOne("ENVANTERYONETIMI.Models.ProductCategory", "ProductCategory")
                        .WithMany("ProductSubcategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("ENVANTERYONETIMI.Models.PurchaseOrder", b =>
                {
                    b.HasOne("ENVANTERYONETIMI.Models.Vendor", "Vendor")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("VendorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("ENVANTERYONETIMI.Models.Location", b =>
                {
                    b.Navigation("ProductInventories");
                });

            modelBuilder.Entity("ENVANTERYONETIMI.Models.Product", b =>
                {
                    b.Navigation("ProductInventories");
                });

            modelBuilder.Entity("ENVANTERYONETIMI.Models.ProductCategory", b =>
                {
                    b.Navigation("ProductSubcategories");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ENVANTERYONETIMI.Models.ProductSubcategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ENVANTERYONETIMI.Models.Vendor", b =>
                {
                    b.Navigation("PurchaseOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
