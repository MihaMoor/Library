using Book.API.Application.ViewModels;
using Book.API.Extensions;
using Book.Infrastructure.Repositories;

namespace Book.API.Application.Queries.Book;

public class BookQueries(UnitOfWork unitOfWork) : IBookQueries
{
    public async Task<BookViewModel?> GetAsync(Guid id)
        => unitOfWork.BookRepository
        .Get(filter: x => x.Id == id)
        .ToViewModel();

    public IAsyncEnumerable<BookViewModel> GetAsync()
        => unitOfWork.BookRepository.Get().ToViewModel();

    public IAsyncEnumerable<BookViewModel> GetByAuthorAsync(Guid authorId)
        => unitOfWork.GetByAuthorAsync(authorId).ToViewModel();

    public IAsyncEnumerable<BookViewModel> GetByPublishingHouseAsync(Guid publishingHouseId)
        => unitOfWork.GetByPublishingHouseAsync(publishingHouseId).ToViewModel();
}
