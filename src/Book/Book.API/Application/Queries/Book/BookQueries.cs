using Book.API.Application.ViewModels;
using Book.API.Extensions;
using Book.Infrastructure;

namespace Book.API.Application.Queries.Book;

public class BookQueries : IBookQueries
{
    private readonly BookContext _context;

    public BookQueries(BookContext context)
        => _context = context;

    public async Task<BookViewModel> GetBookAsync(Guid id)
    {
        Domain.AggregatesModel.Book? book = await _context.Books.FindAsync(id);

        return book == null ? throw new KeyNotFoundException(id.ToString()) : book.ToViewModel();
    }

    public Task<IAsyncEnumerable<BookViewModel>> GetBooksAsync() => throw new NotImplementedException();

    public Task<IAsyncEnumerable<BookViewModel>> GetBooksFromAuthorAsync(Guid authorId) => throw new NotImplementedException();

    public Task<IAsyncEnumerable<BookViewModel>> GetBooksFromPublishingHouseAsync(Guid publishingHouseId) => throw new NotImplementedException();
}
