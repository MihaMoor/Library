using Book.API.Application.ViewModels;
using Book.Domain.Interfaces;

namespace Book.API.Application.Queries.Book;

public interface IBookQueries : IQueries
{
    Task<BookViewModel?> GetBookAsync(Guid id);

    Task<IAsyncEnumerable<BookViewModel>> GetAsync();

    Task<IAsyncEnumerable<BookViewModel>> GetByAuthorAsync(Guid authorId);

    Task<IAsyncEnumerable<BookViewModel>> GetByPublishingHouseAsync(Guid publishingHouseId);
}
