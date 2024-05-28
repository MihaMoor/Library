using Book.API.Application.ViewModels;
using Book.API.Extensions;
using Book.Domain.AggregatesModel.BookAggregate;

namespace Book.API.Application.Queries.Book;

public class BookQueries(IBookRepository bookRepository) : IBookQueries
{
    public async Task<BookViewModel?> GetAsync(Guid id)
        => (await bookRepository
            .GetAsync(id))?
            .ToViewModel();

    public IAsyncEnumerable<BookViewModel> GetAsync()
        => bookRepository.GetAsync().ToViewModel();

    public IAsyncEnumerable<BookViewModel> GetByAuthorAsync(Guid authorId)
        => bookRepository.GetByAuthorAsync(authorId).ToViewModel();

    public IAsyncEnumerable<BookViewModel> GetByPublishingHouseAsync(Guid publishingHouseId)
        => bookRepository.GetByPublishingHouseAsync(publishingHouseId).ToViewModel();
}
