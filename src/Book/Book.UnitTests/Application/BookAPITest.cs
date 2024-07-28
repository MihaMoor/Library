using Book.Infrastructure;

namespace Book.UnitTests.Application;

public partial class BookAPITest
{
    [Theory]
    [MemberData(nameof(BookApiTestDataGetExistingBookById))]
    public void GetExistingBookById(Guid id, BookContext context)
    {
        Domain.AggregatesModel.Book? book = context.Books.SingleOrDefault(x => x.Id == id);

        Assert.NotNull(book);
    }

    [Theory]
    [MemberData(nameof(BookAPITestDataGetFaildBookById))]
    public void GetFaildBookById(Guid id, BookContext context)
    {
        Domain.AggregatesModel.Book? book = context.Books.SingleOrDefault(x => x.Id == id);
        Assert.Null(book);
    }
}
