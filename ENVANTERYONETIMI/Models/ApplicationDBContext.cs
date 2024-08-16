using Microsoft.EntityFrameworkCore;
namespace ENVANTERYONETIMI.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
        }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInventory> ProductInventories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .ToTable("ProductCategory");
            modelBuilder.Entity<ProductSubcategory>()
                .ToTable("ProductSubcategory");
            modelBuilder.Entity<Product>()
                .ToTable("Product");
            modelBuilder.Entity<ProductInventory>()
                .ToTable("ProductInventory");
            modelBuilder.Entity<Location>()
                .ToTable("Location");
            modelBuilder.Entity<Vendor>()
                .ToTable("Vendor");
            modelBuilder.Entity<PurchaseOrder>()
                .ToTable("PurchaseOrder");
            modelBuilder.Entity<ProductModel>()
                .ToTable("ProductModel");




            //tablolar arası ilişkiler
            modelBuilder.Entity<ProductCategory>()
                .HasMany(p => p.ProductSubcategories)  // 'ProductCategory' sınıfının 'ProductSubcategories' koleksiyonuna sahip olduğunu belirtir.
                .WithOne(pi => pi.ProductCategory)     // 'ProductSubcategory' sınıfında, 'ProductCategory' ile ilişkili bir navigation property olduğunu belirtir.
                .HasForeignKey(pi => pi.CategoryID)
                .OnDelete(DeleteBehavior.Restrict);     // 'ProductSubcategory' tablosundaki 'CategoryID' foreign key alanı, 'ProductCategory' tablosuna referans verir.

            modelBuilder.Entity<ProductCategory>()
                .HasMany(p => p.Products)  
                .WithOne(pi => pi.ProductCategory)     
                .HasForeignKey(pi => pi.CategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductSubcategory>()
                .HasMany(p => p.Products)
                .WithOne(pi => pi.ProductSubcategory)
                .HasForeignKey(pi => pi.SubcategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductInventories)
                .WithOne(pi => pi.Product)
                .HasForeignKey(pi => pi.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Location>()
                .HasMany(p => p.ProductInventories)
                .WithOne(pi => pi.Location)
                .HasForeignKey(pi => pi.LocationID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vendor>()
                .HasMany(p => p.PurchaseOrders)
                .WithOne(pi => pi.Vendor)
                .HasForeignKey(pi => pi.VendorID)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
