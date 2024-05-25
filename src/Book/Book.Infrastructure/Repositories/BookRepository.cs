using Book.Domain.AggregatesModel;
using Book.Domain.AggregatesModel.BookAggregate;
using Microsoft.EntityFrameworkCore;

namespace Book.Infrastructure.Repositories;

public class BookRepository(BookContext context) : IBookRepository, IDisposable
{
    private bool _disposed;

    public IAsyncEnumerable<Domain.AggregatesModel.Book> GetAsync()
        => context.Books.AsAsyncEnumerable();

    public async Task<Domain.AggregatesModel.Book?> GetAsync(Guid id)
        => await context.Books.FindAsync(id);

    public async IAsyncEnumerable<Domain.AggregatesModel.Book> GetByAuthorAsync(Guid authorId)
    {
        // Иначе получается очень большая строка, а из правой части в целом понятно какой тип позвращается.
#pragma warning disable IDE0008 // Use explicit type
        var books = context.Books.Where(x => x.Author.Id == authorId).AsAsyncEnumerable();
#pragma warning restore IDE0008 // Use explicit type
        await foreach (Domain.AggregatesModel.Book book in books)
        {
            yield return book;
        }
    }

    public async IAsyncEnumerable<Domain.AggregatesModel.Book> GetByPublishingHouseAsync(Guid publishingHouseId)
    {
        // Иначе получается очень большая строка, а из правой части в целом понятно какой тип позвращается.
#pragma warning disable IDE0008 // Use explicit type
        var books = context.Books.Where(x => x.PublishingHouse.Id == publishingHouseId).AsAsyncEnumerable();
#pragma warning restore IDE0008 // Use explicit type
        await foreach (Domain.AggregatesModel.Book book in books)
        {
            yield return book;
        }
    }

    public void Insert(Domain.AggregatesModel.Book book)
        => context.Books.Add(book);

    public void Update(Domain.AggregatesModel.Book book)
        => context.Entry(book).State = EntityState.Modified;

    public void Delete(Guid id)
    {
        Domain.AggregatesModel.Book? book = context.Books.Find(id);
        if (book != null) context.Books.Remove(book);
    }

    public void Save()
        => context.SaveChanges();

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
