using Book.Infrastructure;

namespace Book.UnitTests.Application;

public partial class BookApiTest
{
    public static TheoryData<Guid, BookContext> BookAPITestDataGetFaildBookById
        => new()
        {
            { Guid.NewGuid(), new InMemoryBookDB().Context },
            { Guid.NewGuid(), new InMemoryBookDB().Context },
            { Guid.NewGuid(), new InMemoryBookDB().Context },
            { Guid.NewGuid(), new InMemoryBookDB().Context }
        };

    public static TheoryData<Guid, BookContext, Domain.AggregatesModel.Book> BookApiTestDataGetExistingBookById => new()
    {
        {
            Guid.Parse("46A9B344-72D1-44CC-BA07-6B79F5E95567"),
            new InMemoryBookDB().Context,
            new Domain.AggregatesModel.Book()
            {
                Id = Guid.Parse("46A9B344-72D1-44CC-BA07-6B79F5E95567"),
                Title = "Test1",
                Year = DateTime.Parse("01.01.2001"),
                Author = new()
                {
                    Id = Guid.Parse("46A9B344-72D1-44CC-BA07-6B79F5E95567"),
                    BirthYear = DateTime.Parse("01.01.1991"),
                    Name = "Test",
                    Surname = "Testovich"
                },
                PublishingHouse = new()
                {
                    Id = Guid.Parse("46A9B344-72D1-44CC-BA07-6B79F5E95567"),
                    FoundationYear = DateTime.Parse("01.01.2000"),
                    Name = "Test house"
                }
            }
        },
    };
}
