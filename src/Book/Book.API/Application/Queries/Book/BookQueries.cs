using Book.API.Application.ViewModels;
using Book.API.Extensions;
using Book.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Book.API.Application.Queries.Book;

public class BookQueries(BookContext context) : IBookQueries
{
    public async Task<Results<Ok<BookViewModel>, BadRequest<string>>> GetBookAsync(Guid id)
    {
        Domain.AggregatesModel.Book? book = await context.Books.FindAsync(id);

        return book == null
            ? TypedResults.BadRequest(id.ToString())
            : TypedResults.Ok(book.ToViewModel());
    }

    public Task<IAsyncEnumerable<BookViewModel>> GetBooksAsync() => throw new NotImplementedException();

    public Task<IAsyncEnumerable<BookViewModel>> GetBooksFromAuthorAsync(Guid authorId) => throw new NotImplementedException();

    public Task<IAsyncEnumerable<BookViewModel>> GetBooksFromPublishingHouseAsync(Guid publishingHouseId) => throw new NotImplementedException();
}
