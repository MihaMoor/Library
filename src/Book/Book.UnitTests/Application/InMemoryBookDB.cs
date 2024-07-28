using Book.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Book.UnitTests.Application;

public class InMemoryBookDB
{
    public readonly BookContext context;

    public InMemoryBookDB()
    {
        DbContextOptionsBuilder<BookContext> builder = new();
        builder.UseInMemoryDatabase(databaseName: "Book");

        DbContextOptions<BookContext> dbContextOptions = builder.Options;
        context = new BookContext(dbContextOptions);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        SeedData();
    }

    private void SeedData()
    {
        Domain.AggregatesModel.Book book = new()
        {
            Id = Guid.Parse("46A9B344-72D1-44CC-BA07-6B79F5E95567"),
            Title = "Test1",
            Year = DateTime.Parse("01.01.2001")
        };
        context.Books.Add(book);
        context.SaveChanges();
    }
}
