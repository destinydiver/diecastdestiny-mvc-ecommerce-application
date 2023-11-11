using DiecastDestiny.Models;
using Microsoft.EntityFrameworkCore;

namespace DiecastDestiny.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSupplier>().HasKey(ps => new
            {
                ps.ProductId,
                ps.SupplierId
            });

            modelBuilder.Entity<ProductSupplier>()
                .HasOne(p => p.Product)
                .WithMany(ps => ps.ProductsSuppliers)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<ProductSupplier>()
                .HasOne(s => s.Supplier)
                .WithMany(s => s.ProductsSuppliers)
                .HasForeignKey(s => s.SupplierId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductSupplier> ProductsSuppliers { get; set; }
        
    }
}
