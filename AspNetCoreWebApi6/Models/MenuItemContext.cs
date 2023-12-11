using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApi6.Models
{
    public class MenuItemContext : DbContext
    {
        public MenuItemContext(DbContextOptions<MenuItemContext> options)
            : base(options)
        {
        }

        public DbSet<MenuItem> Menu_Items { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18, 2)"); // Adjust precision and scale as needed

            base.OnModelCreating(modelBuilder);
        }
    }
}
