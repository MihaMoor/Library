using Book.API.Application.ViewModels;
using Book.Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Book.API.Application.Queries.Book;

public interface IBookQueries : IQueries
{
    Task<Results<Ok<BookViewModel>, BadRequest<string>>> GetBookAsync(Guid id);
    Task<IAsyncEnumerable<BookViewModel>> GetBooksAsync();
    Task<IAsyncEnumerable<BookViewModel>> GetBooksFromAuthorAsync(Guid authorId);
    Task<IAsyncEnumerable<BookViewModel>> GetBooksFromPublishingHouseAsync(Guid publishingHouseId);
}
