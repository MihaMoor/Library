using Book.API.Application.ViewModels;
using Book.API.Extensions;
using Book.Infrastructure;

namespace Book.API.Application.Queries.Book;

public class BookQueries(BookContext context) : IBookQueries
{
    public async Task<BookViewModel?> GetBookAsync(Guid id)
        => (await context.Books.FindAsync(id))?.ToViewModel();

    public async IAsyncEnumerable<BookViewModel> GetBooksAsync()
    {
        await foreach (Domain.AggregatesModel.Book book in context.Books)
        {
            yield return book.ToViewModel();
        }
    }

    IAsyncEnumerable<BookViewModel> IBookQueries.GetBooksFromAuthorAsync(Guid authorId)
        => throw new NotImplementedException();

    IAsyncEnumerable<BookViewModel> IBookQueries.GetBooksFromPublishingHouseAsync(Guid publishingHouseId)
        => throw new NotImplementedException();
}
