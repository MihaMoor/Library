using Book.Domain.AggregatesModel;

namespace Book.Infrastructure.Repositories;

public class UnitOfWork(BookContext context) : IDisposable
{
    private Repository<Domain.AggregatesModel.Book> _bookRepository = null!;
    private Repository<Author> _authorRepository = null!;
    private Repository<PublishingHouse> _publishingHouseRepository = null!;

    private bool _disposed;

    public Repository<Domain.AggregatesModel.Book> BookRepository
    {
        get
        {
            _bookRepository ??= new(context);
            return _bookRepository;
        }
    }

    public Repository<Author> AuthorRepository
    {
        get
        {
            _authorRepository ??= new(context);
            return _authorRepository;
        }
    }

    public Repository<PublishingHouse> PublishingHouseRepository
    {
        get
        {
            _publishingHouseRepository ??= new(context);
            return _publishingHouseRepository;
        }
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
