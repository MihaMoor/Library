using Confluent.Kafka;
using Shared.ServiceDefaults.Kafka;

namespace Book.API.Application.BackgroundWorkers;

public class BookMagazineUpdateWorker(
    IServiceProvider serviceProvider,
    IConsumer<Null, BookMagazineUpdateModel> consumer,
    ILogger<BookMagazineUpdateWorker> logger)
    : KafkaConsumerWorker<Null, BookMagazineUpdateModel>(
        consumer,
        logger,
        TopicNames.BookMagazineUpdateTopic)
{
    public override async Task Handle(CancellationToken stoppingToken)
    {
        ConsumeResult<Null, BookMagazineUpdateModel> result = Consumer.Consume(stoppingToken);

        if (result == null) return;
        if (result.Message.Value == null) return;

        BookMagazineUpdateModel model = result.Message.Value;

        await Console.Out.WriteLineAsync(model.ToString());
    }
}
