using Confluent.Kafka;
using Shared.ServiceDefaults.Kafka;

namespace Book.API.BackgroundWorkers;

/// <summary>
/// Сервис для обработки сообщений от Spatial для создания и редактирования сущностей.
/// </summary>
public class BookMagazineUpdateWorker(
    IConsumer<string, BookMagazineUpdateModel> consumer,
    ILogger<BookMagazineUpdateWorker> logger)
    : KafkaConsumerWorker<string, BookMagazineUpdateModel>(
        consumer,
        logger,
        TopicNames.BookMagazineUpdateTopic)
{
    /// <inheritdoc/>    
    public override async Task Handle(CancellationToken stoppingToken)
    {
        ConsumeResult<string, BookMagazineUpdateModel> result = Consumer.Consume(stoppingToken);

        if (result == null) return;
        if (result.Message.Value == null) return;

        await Console.Out.WriteLineAsync(result.Message.Value.ToString());
    }
}