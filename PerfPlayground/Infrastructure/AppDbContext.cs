using Microsoft.EntityFrameworkCore;
using PerfPlayground.Domain;

namespace PerfPlayground.Infrastructure
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<Product>(e =>
            {
                e.Property(p => p.Name).HasMaxLength(200).IsRequired();
                e.HasIndex(p => p.Name);//for searching

                e.HasIndex(p => new { p.CategoryId, p.Price })//for complex searching
                .IncludeProperties(p => new { p.Name, p.Stock, p.CreatedAt });
            });

            b.Entity<Customer>(e =>
            {
                e.HasIndex(c => c.Email).IsUnique();
                e.Property(c => c.Email).HasMaxLength(200).IsRequired();
            });

            b.Entity<Order>(e =>
            {
                e.HasIndex(o => o.PlacedAt);
                e.HasMany(o => o.Items).WithOne(i => i.Order).HasForeignKey(i => i.OrderId);
            });

            b.Entity<OrderItem>(e =>
            {
                e.HasIndex(i => i.ProductId);
            });
        }
    }
}