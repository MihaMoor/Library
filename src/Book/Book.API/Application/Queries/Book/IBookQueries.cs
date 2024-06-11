using Book.API.Application.ViewModels;
using Book.Domain.Interfaces;

namespace Book.API.Application.Queries.Book;

public interface IBookQueries : IQueries
{
    Task<BookViewModel?> GetBookAsync(Guid id);

    IAsyncEnumerable<BookViewModel> GetBooksAsync();

    IAsyncEnumerable<BookViewModel> GetBooksFromAuthorAsync(Guid authorId);

    IAsyncEnumerable<BookViewModel> GetBooksFromPublishingHouseAsync(Guid publishingHouseId);
}
