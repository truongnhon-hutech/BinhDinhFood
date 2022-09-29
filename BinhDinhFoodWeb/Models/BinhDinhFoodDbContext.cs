using BinhDinhFoodWeb.Models;
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
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<Banner> Blogs{ get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Discount> Discounts{ get; set; }
        public DbSet<DiscountDetail> DiscountDetails{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductRating>().ToTable("ProductRating");
            modelBuilder.Entity<Banner>().ToTable("Blog");
            modelBuilder.Entity<Token>().ToTable("Token");
            modelBuilder.Entity<Banner>().ToTable("Banner");
            modelBuilder.Entity<Favorite>().ToTable("Favorite");
            modelBuilder.Entity<Discount>().ToTable("Discount");
            modelBuilder.Entity<DiscountDetail>().ToTable("DiscountDetail");

            modelBuilder.Entity<OrderDetail>()
                .HasKey(c => new { c.ProductId, c.OrderId });

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails);

            modelBuilder.Entity<DiscountDetail>()
                .HasKey(c => new { c.DiscountId, c.ProductId });

            modelBuilder.Entity<Discount>()
                .HasMany(e => e.DiscountDetails);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.DiscountDetails);

            modelBuilder.Entity<Favorite>()
               .HasKey(c => new { c.ProductId, c.CustomerId });

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Favorites);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Favorites);

            modelBuilder.Entity<Product>()
                .HasMany(g => g.ProductRatings);

            modelBuilder.Entity<Customer>()
                .HasMany(g => g.ProductRatings);

            modelBuilder.Entity<Product>()
               .HasMany(g => g.Favorites);

            modelBuilder.Entity<Customer>()
                .HasMany(g => g.Favorites);

            modelBuilder.Entity<Admin>()
                .HasIndex(g => g.AdminUserName)
                .IsUnique();  
            
            modelBuilder.Entity<Customer>()
                .HasIndex(g => g.CustomerUserName)
                .IsUnique();            

        }

        public DbSet<BinhDinhFoodWeb.Models.Blog>? Blog { get; set; }
    }
}
