using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Book.Infrastructure.Repositories;

public class Repository<T> where T : class
{
    private static readonly char[] separator = [','];
    internal BookContext _context;
    internal DbSet<T> dbSet;

    // Как сказал Эндрю Лок: "Неявные поля изменяют макет". И тут это хорошо видно.
    public Repository(BookContext context)
    {
        _context = context;
        dbSet = context.Set<T>();
    }

    public virtual IAsyncEnumerable<T> Get(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        string includeProperties = "") // Должна быть константой времени компиляции, поэтому `string.Empty` не работает.
    {
        IQueryable<T> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split(separator, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        return orderBy != null 
            ? orderBy(query).AsAsyncEnumerable() 
            : query.AsAsyncEnumerable();
    }

    public virtual T? GetByID(Guid id)
        => dbSet.Find(id);

    public virtual void Insert(T entity)
        => dbSet.Add(entity);

    public virtual void Delete(Guid id)
    {
        T? entityToDelete = dbSet.Find(id);

        if (entityToDelete != null)
        {
            Delete(entityToDelete);
        }
    }

    public virtual void Delete(T entityToDelete)
    {
        if (_context.Entry(entityToDelete).State == EntityState.Detached)
        {
            dbSet.Attach(entityToDelete);
        }

        dbSet.Remove(entityToDelete);
    }

    public virtual void Update(T entityToUpdate)
    {
        dbSet.Attach(entityToUpdate);
        _context.Entry(entityToUpdate).State = EntityState.Modified;
    }
}
