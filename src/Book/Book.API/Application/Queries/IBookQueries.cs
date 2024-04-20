using Book.Domain.Interfaces;

namespace Book.API.Application.Queries;

public interface IBookQueries : IQueries
{
    Task<BookViewModel> GetBookAsync();
    Task<BookViewModel> GetBookAsync(Guid id);
    Task<IAsyncEnumerable<BookViewModel>> GetBooksAsync();
    Task<IAsyncEnumerable<BookViewModel>> GetBooksFromAuthorAsync(Guid authorId);
    Task<IAsyncEnumerable<BookViewModel>> GetBooksFromPublishingHouseAsync(Guid publishingHouseId);
}
