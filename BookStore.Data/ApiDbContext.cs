using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(x => x.Category);

            modelBuilder.Entity<Inventory>()
                .HasMany(x => x.Books);

            modelBuilder.Entity<Category>()
                .HasMany(x => x.Books);

            modelBuilder.Entity<Order>()
               .ToTable(nameof(Order));

            modelBuilder.Entity<Category>()
                .ToTable(nameof(Category));

            modelBuilder.Entity<Book>()
                .ToTable(nameof(Book));

            modelBuilder.Entity<Inventory>()
                .ToTable(nameof(Inventory));
        }
    }
}
