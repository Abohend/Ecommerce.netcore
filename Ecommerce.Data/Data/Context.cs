using Ecommerce.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.DataAccess.Data
{
    public class Context: IdentityDbContext<ApplicationUser>
    {
        private readonly IConfiguration _configuration;

        public Context(DbContextOptions<Context> options, IConfiguration configuration): base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(c => c.CreatedTime)
                .HasDefaultValueSql("GETDATE()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasNoKey();

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasKey(e => new { e.RoleId, e.UserId });

            modelBuilder.Entity<IdentityUserToken<string>>()
                .HasNoKey();

            modelBuilder.Entity<ShoppingCartItem>()
                .HasKey(e => new { e.ProductId, e.UserId });

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId });

            #region Seed Data
            modelBuilder.SeedRoles();
            modelBuilder.SeedAdminUser(_configuration);
            modelBuilder.SeedCustomerUsers(_configuration);
            modelBuilder.SeedCategories();
            modelBuilder.SeedProducts();
            modelBuilder.SeedContactInfo();
            #endregion
        }
    }
}
