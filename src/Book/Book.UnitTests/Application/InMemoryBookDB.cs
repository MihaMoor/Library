using Book.Domain.AggregatesModel;
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
        Author author = new()
        {
            Id = Guid.Parse("46A9B344-72D1-44CC-BA07-6B79F5E95567"),
            BirthYear = DateTime.Parse("01.01.1991"),
            Name = "Test",
            Surname = "Testovich"
        };

        PublishingHouse house = new()
        {
            Id = Guid.Parse("46A9B344-72D1-44CC-BA07-6B79F5E95567"),
            FoundationYear = DateTime.Parse("01.01.2000"),
            Name = "Test house"
        };

        Domain.AggregatesModel.Book book = new()
        {
            Id = Guid.Parse("46A9B344-72D1-44CC-BA07-6B79F5E95567"),
            Title = "Test1",
            Year = DateTime.Parse("01.01.2001"),
            Author = author,
            PublishingHouse = house
        };

        context.Books.Add(book);
        context.Authors.Add(author);
        context.SaveChanges();
    }
}
