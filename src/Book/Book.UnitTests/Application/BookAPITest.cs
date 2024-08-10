using Book.API.Application.Queries.Book;
using Book.API.Application.ViewModels;
using Book.API.Extensions;
using Book.Infrastructure;

namespace Book.UnitTests.Application;

public partial class BookApiTest
{
    [Theory]
    [MemberData(nameof(BookApiGetExistingBookById))]
    public async void GetExistingBookById(Guid id, BookContext context, Domain.AggregatesModel.Book expectedBook)
    {
        BookQueries bookQueries = new(context);
        BookViewModel? book = await bookQueries.GetBookAsync(id);

        Assert.NotNull(book);
        Assert.Equal(book, expectedBook.ToViewModel());
    }

    [Theory]
    [MemberData(nameof(BookApiGetFaildBookById))]
    public void GetFaildBookById(Guid id, BookContext context)
    {
        Domain.AggregatesModel.Book? book = context.Books.SingleOrDefault(x => x.Id == id);
        Assert.Null(book);
    }

    [Theory]
    [ClassData(typeof(BookApiGetBooks))]
    public async void GetBooks(BookViewModel bookViewModel)
    {
        BookApiGetBooks getBooks = new();
        getBooks.SeedBooks();

        BookQueries bookQueries = new(getBooks.Context);
        IAsyncEnumerable<BookViewModel> books = bookQueries.GetBooksAsync();

        await foreach (BookViewModel book in books)
        {
            if (book.Id == bookViewModel.Id)
            {
                Assert.True(true);
                return;
            }
        }

        Assert.True(false);
    }
}
