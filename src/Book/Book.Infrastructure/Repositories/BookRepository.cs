using Book.Domain;
using Book.Domain.AggregatesModel.BookAggregate;
using Microsoft.EntityFrameworkCore;

namespace Book.Infrastructure.Repositories;

public class BookRepository(BookContext context) : IBookRepository
{
    public IUnitOfWork UnitOfWork => context;

    public IAsyncEnumerable<Domain.AggregatesModel.Book> GetAsync()
        => context.Books
        .Include(x => x.Author)
        .Include(x => x.PublishingHouse)
        .AsAsyncEnumerable();

    public async Task<Domain.AggregatesModel.Book?> GetAsync(Guid id)
        => await context.Books
        .Include(x => x.Author)
        .Include(x => x.PublishingHouse)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async IAsyncEnumerable<Domain.AggregatesModel.Book> GetByAuthorAsync(Guid authorId)
    {
        // Иначе получается очень большая строкаа из правой части в целом понятно какой тип позвращается.
#pragma warning disable IDE0008 // Use explicit type
        var books = context.Books
            .Include(x => x.Author)
            .Include(x => x.PublishingHouse)
            .Where(x => x.Author.Id == authorId)
            .AsAsyncEnumerable();
#pragma warning restore IDE0008 // Use explicit type
        await foreach (Domain.AggregatesModel.Book book in books)
        {
            yield return book;
        }
    }

    public async IAsyncEnumerable<Domain.AggregatesModel.Book> GetByPublishingHouseAsync(Guid publishingHouseId)
    {
        // Иначе получается очень большая строкаа из правой части в целом понятно какой тип позвращается.
#pragma warning disable IDE0008 // Use explicit type
        var books = context.Books
            .Include(x => x.Author)
            .Include(x => x.PublishingHouse)
            .Where(x => x.PublishingHouse.Id == publishingHouseId)
            .AsAsyncEnumerable();
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
        => context.SaveChangesAsync();
}
