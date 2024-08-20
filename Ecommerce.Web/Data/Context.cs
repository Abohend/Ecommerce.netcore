using Ecommerce.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Web.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options): base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(c => c.CreatedTime)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
