namespace Book.API.Application.Queries;

public class BookQueries : IBookQueries
{
    public Task<BookViewModel> GetBookAsync() => throw new NotImplementedException();
    public Task<BookViewModel> GetBookAsync(Guid id) => throw new NotImplementedException();
    public Task<IAsyncEnumerable<BookViewModel>> GetBooksAsync() => throw new NotImplementedException();
    public Task<IAsyncEnumerable<BookViewModel>> GetBooksFromAuthorAsync(Guid authorId) => throw new NotImplementedException();
    public Task<IAsyncEnumerable<BookViewModel>> GetBooksFromPublishingHouseAsync(Guid publishingHouseId) => throw new NotImplementedException();
}
