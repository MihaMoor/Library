using Microsoft.EntityFrameworkCore;

namespace Book.Infrastructure;

public class BookContext : DbContext
{
    public DbSet<Domain.AgregatesModel.Book> Books { get; set; }

    public BookContext(DbContextOptions<BookContext> options) : base(options) { }

    public BookContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}
