using Book.API.Application.Queries;

namespace Book.API.Extensions;

public static class BookExtensions
{
    public static async IAsyncEnumerable<BookViewModel> ToViewModel(this IAsyncEnumerable<Domain.AgregatesModel.Book> books)
    {
        await foreach (Domain.AgregatesModel.Book book in books)
        {
            yield return book.ToViewModel();
        }
    }

    public static BookViewModel ToViewModel(this Domain.AgregatesModel.Book book)
        => new(
            book.Id,
            book.Title,
            book.Description,
            book.Year,
            book.Author,
            book.PublishingHouse
        );
}
