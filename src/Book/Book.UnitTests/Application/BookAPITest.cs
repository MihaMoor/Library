using Book.API.Application.Queries.Book;
using Book.API.Application.ViewModels;
using Book.API.Extensions;
using Book.Infrastructure;

namespace Book.UnitTests.Application;

public partial class BookAPITest
{
    [Theory]
    [MemberData(nameof(BookApiTestDataGetExistingBookById))]
    public async void GetExistingBookById(Guid id, BookContext context, Domain.AggregatesModel.Book expectedBook)
    {
        BookQueries bookQueries = new(context);
        BookViewModel? book = await bookQueries.GetBookAsync(id);

        Assert.NotNull(book);
        Assert.Equal(book, expectedBook.ToViewModel());
    }

    [Theory]
    [MemberData(nameof(BookAPITestDataGetFaildBookById))]
    public void GetFaildBookById(Guid id, BookContext context)
    {
        Domain.AggregatesModel.Book? book = context.Books.SingleOrDefault(x => x.Id == id);
        Assert.Null(book);
    }
}
