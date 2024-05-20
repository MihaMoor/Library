using Book.API.Application.ViewModels;
using Book.Domain.Interfaces;

namespace Book.API.Application.Queries.Book;

public interface IBookQueries : IQueries
{
    Task<BookViewModel?> GetBookAsync(Guid id);

    Task<IAsyncEnumerable<BookViewModel>> GetBooksAsync();

    Task<IAsyncEnumerable<BookViewModel>> GetBooksFromAuthorAsync(Guid authorId);

    Task<IAsyncEnumerable<BookViewModel>> GetBooksFromPublishingHouseAsync(Guid publishingHouseId);
}
