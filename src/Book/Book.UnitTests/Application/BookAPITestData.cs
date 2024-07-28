using Book.Infrastructure;

namespace Book.UnitTests.Application;

public partial class BookAPITest
{
    public static TheoryData<Guid, BookContext> BookAPITestDataGetFaildBookById => new()
    {
        { Guid.NewGuid(), new InMemoryBookDB().context },
        { Guid.NewGuid(), new InMemoryBookDB().context },
        { Guid.NewGuid(), new InMemoryBookDB().context },
        { Guid.NewGuid(), new InMemoryBookDB().context }
    };

    public static TheoryData<Guid, BookContext> BookApiTestDataGetExistingBookById => new()
    {
        { Guid.Parse("46A9B344-72D1-44CC-BA07-6B79F5E95567"), new InMemoryBookDB().context }
    };
}
