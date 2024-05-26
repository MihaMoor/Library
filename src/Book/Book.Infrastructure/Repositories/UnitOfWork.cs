using Book.Domain.AggregatesModel;

namespace Book.Infrastructure.Repositories;

public class UnitOfWork : IDisposable
{
    private BookContext _context;
    private Repository<Domain.AggregatesModel.Book> _bookRepository;
    private Repository<Author> _authorRepository;
    private Repository<PublishingHouse> _publishingHouseRepository;

    private bool _disposed;

    public Repository<Domain.AggregatesModel.Book> BookRepository
    {
        get
        {
            _bookRepository ??= new(_context);
            return _bookRepository;
        }
    }

    public Repository<Author> AuthorRepository
    {
        get
        {
            _authorRepository ??= new(_context);
            return _authorRepository;
        }
    }

    public Repository<PublishingHouse> PublishingHouseRepository
    {
        get
        {
            _publishingHouseRepository ??= new(_context);
            return _publishingHouseRepository;
        }
    }

    public UnitOfWork(BookContext context)
        => _context = context;

    public void Save()
        => _context.SaveChanges();

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
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
