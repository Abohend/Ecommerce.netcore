using Ecommerce.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ecommerce.DataAccess.Data
{
    public class Context: IdentityDbContext<ApplicationUser>
    {
        public Context(DbContextOptions<Context> options): base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(c => c.CreatedTime)
                .HasDefaultValueSql("GETDATE()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasNoKey();

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasNoKey();

            modelBuilder.Entity< IdentityUserToken<string>>()
                .HasNoKey();
        }
	}
}
