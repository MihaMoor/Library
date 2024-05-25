namespace Book.Domain.AggregatesModel.BookAggregate;

public interface IBookRepository : IDisposable
{
    IAsyncEnumerable<Book> GetAsync();
    Task<Book?> GetAsync(Guid id);
    IAsyncEnumerable<Book> GetByAuthorAsync(Guid authorId);
    IAsyncEnumerable<Book> GetByPublishingHouseAsync(Guid publishingHouseId);
    void Insert(Book book);
    void Update(Book book);
    void Delete(Guid id);
    void Save();
}
