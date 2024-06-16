using Confluent.Kafka;
using Microsoft.Extensions.Logging;

namespace Shared.ServiceDefaults.Kafka;

public class KafkaMessageProducer<T, K>(IProducer<T, K> producer, ILogger<KafkaMessageProducer<T, K>> logger)
{
    public virtual async Task ProduceAsync(string topic, Message<T, K> message, string? logMessage = null)
    {
        try
        {
            DeliveryResult<T, K> result = await producer.ProduceAsync(topic, message);

            logMessage = string.Format(
                "Produce: Topic='{0}', Offset='{1}', userMessage={2}",
                result.TopicPartition,
                result.Offset,
                logMessage ?? "empty");

            logger.LogInformation(logMessage);
        }
        catch (ProduceException<T, K> ex)
        {
            logger.LogError(ex.Message);
        }
    }
}
