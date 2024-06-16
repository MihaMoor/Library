using Book.API.Application.ViewModels;
using Book.API.Extensions;
using Book.Infrastructure;
using Confluent.Kafka;
using Shared.ServiceDefaults.Kafka;

namespace Book.API.Application.Queries.Book;

public class BookQueries(
    BookContext context,
    KafkaMessageProducer<Null, BookMagazineUpdateModel> producer,
    ILogger<BookQueries> logger)
    : IBookQueries
{
    public async Task<BookViewModel?> GetBookAsync(Guid id)
        => (await context.Books.FindAsync(id))?.ToViewModel();

    public IAsyncEnumerable<BookViewModel> GetBooksAsync()
    {
        Message<Null, BookMagazineUpdateModel> message = new()
        {
            Value = new(
                Guid.NewGuid(),
                BookMagazineEntityType.PublishingHouse,
                [],
                BookMagazineOperation.Create)
        };

        producer.ProduceAsync(TopicNames.BookMagazineUpdateTopic, message);

        IAsyncEnumerable<BookViewModel> empty = AsyncEnumerable.Empty<BookViewModel>();
        return empty;
    }

    public IAsyncEnumerable<BookViewModel> GetBooksFromAuthorAsync(Guid authorId) => throw new NotImplementedException();

    public IAsyncEnumerable<BookViewModel> GetBooksFromPublishingHouseAsync(Guid publishingHouseId) => throw new NotImplementedException();
}
