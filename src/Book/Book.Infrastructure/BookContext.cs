using Book.Domain;
using Microsoft.EntityFrameworkCore;

namespace Book.Infrastructure;

public class BookContext : DbContext, IUnitOfWork
{
    public DbSet<Domain.AggregatesModel.Book> Books { get; set; }
    public DbSet<Domain.AggregatesModel.Author> Authors { get; set; }
    public DbSet<Domain.AggregatesModel.PublishingHouse> PublishingHouses { get; set; }

    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        => await base.SaveChangesAsync(cancellationToken) > 0;
}
