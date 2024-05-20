using Book.API.Application.ViewModels;

namespace Book.API.Extensions;

public static class BookExtensions
{
    public static async IAsyncEnumerable<BookViewModel> ToViewModel(this Domain.AggregatesModel.Book _, IAsyncEnumerable<Domain.AggregatesModel.Book> books)
    {
        await foreach (Domain.AggregatesModel.Book book in books)
        {
            yield return book.ToViewModel();
        }
    }

    public static BookViewModel ToViewModel(this Domain.AggregatesModel.Book book)
        => new(
            book.Id,
            book.Title,
            book.Description,
            book.Year,
            new(book.Author.Id, $"{book.Author.Name} {book.Author.Surname}"),
            new(book.PublishingHouse.Id, book.PublishingHouse.Name)
        );
}
