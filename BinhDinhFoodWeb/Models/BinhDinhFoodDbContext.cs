using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace BinhDinhFood.Models
{
    public class BinhDinhFoodDbContext:DbContext
    {
        public BinhDinhFoodDbContext(DbContextOptions<BinhDinhFoodDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<OrderDetail>()
                .HasKey(c => new { c.ProductId, c.OrderId });

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails);

        }
    }
}
