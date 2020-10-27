using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class LibraryDataContext : DbContext
    {
        public LibraryDataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.Title).HasMaxLength(200);
            modelBuilder.Entity<Book>().Property(b => b.Author).HasMaxLength(200);
        }
    }
}