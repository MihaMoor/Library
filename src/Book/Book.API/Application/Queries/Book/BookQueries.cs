using Book.API.Application.ViewModels;
using Book.API.Extensions;
using Book.Infrastructure;

namespace Book.API.Application.Queries.Book;

public class BookQueries(BookContext context) : IBookQueries
{
    public async Task<BookViewModel?> GetBookAsync(Guid id)
        => (await context.Books.FindAsync(id))?.ToViewModel();

    public Task<IAsyncEnumerable<BookViewModel>> GetBooksAsync() => throw new NotImplementedException();

    public Task<IAsyncEnumerable<BookViewModel>> GetBooksFromAuthorAsync(Guid authorId) => throw new NotImplementedException();

    public Task<IAsyncEnumerable<BookViewModel>> GetBooksFromPublishingHouseAsync(Guid publishingHouseId) => throw new NotImplementedException();
}
