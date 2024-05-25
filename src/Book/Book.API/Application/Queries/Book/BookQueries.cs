using Book.API.Application.ViewModels;
using Book.API.Extensions;
using Book.Domain.AggregatesModel.BookAggregate;

namespace Book.API.Application.Queries.Book;

public class BookQueries(IBookRepository repository) : IBookQueries
{
    public async Task<BookViewModel?> GetBookAsync(Guid id)
        => (await repository.GetAsync(id))?.ToViewModel();

    public Task<IAsyncEnumerable<BookViewModel>> GetAsync() => throw new NotImplementedException();

    public Task<IAsyncEnumerable<BookViewModel>> GetByAuthorAsync(Guid authorId) => throw new NotImplementedException();

    public Task<IAsyncEnumerable<BookViewModel>> GetByPublishingHouseAsync(Guid publishingHouseId) => throw new NotImplementedException();
}
