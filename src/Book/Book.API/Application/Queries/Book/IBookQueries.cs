using Book.API.Application.ViewModels;
using Book.Domain.Interfaces;

namespace Book.API.Application.Queries.Book;

public interface IBookQueries : IQueries
{
    Task<BookViewModel?> GetAsync(Guid id);

    IAsyncEnumerable<BookViewModel> GetAsync();

    IAsyncEnumerable<BookViewModel> GetByAuthorAsync(Guid authorId);

    IAsyncEnumerable<BookViewModel> GetByPublishingHouseAsync(Guid publishingHouseId);
}
