/*
 * Код представлен исключительно в целях первичного ознакомления 
 * и тестирования возможности взаимодействия приложений с Kafka.
 * 
 * Пример:
 * https://docs.confluent.io/kafka-clients/dotnet/current/overview.html
 * 
 * При первичном разворачивании всей инфраструктуры Producer и Consumer
 * будут пытаться безуспешно установить соединение (ошибка Connection refused).
 * В зависимости от количества безуспешных соединений будет экспоненциально
 * расти время до следующей попытки установления соединения
 * (https://docs.confluent.io/platform/current/installation/configuration/consumer-configs.html#reconnect-backoff-max-ms).
 * 
 * Consumer всегда будет получать первое сообщение из топика.
 * Так было сделано специально, исключительно в целях тестирования.
 */

using Confluent.Kafka;

namespace Client.Shell.Kafka;

internal static class KafkaUsageExample
{
    private const string KafkaServer = "kafka:25092";
    private const string Topic = "test";

    internal static async void Run()
    {
        Task producer = RunProducerAsync(),
            consumer = RunConsumerAsync();

        Task.WaitAll(producer, consumer);
    }

    private static async Task RunProducerAsync()
    {
        await Console.Out.WriteLineAsync("producer start");

        ProducerConfig config = new()
        {
            BootstrapServers = KafkaServer,
            Acks = Acks.All,
            Partitioner = Partitioner.Murmur2
        };

        using IProducer<Null, string> producer = new ProducerBuilder<Null, string>(config).Build();

        Message<Null, string> message = new() { Value = $"test message #{DateTime.Now.Millisecond}" };
        DeliveryResult<Null, string> result = await producer.ProduceAsync(Topic, message);

        await Console.Out.WriteLineAsync($"producer send message '{message.Value}'");
    }

    private static async Task RunConsumerAsync()
    {
        await Console.Out.WriteLineAsync("consumer start");

        ConsumerConfig config = new()
        {
            BootstrapServers = KafkaServer,
            GroupId = "consumers-test",
            AutoOffsetReset = AutoOffsetReset.Earliest,
        };

        using IConsumer<Ignore, string> consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        consumer.Subscribe(Topic);

        bool isMessageHandled = false;
        while (!isMessageHandled)
        {
            ConsumeResult<Ignore, string> result = consumer.Consume();

            isMessageHandled = true;
            await Console.Out.WriteLineAsync($"consumer consume message '{result.Message.Value}'");
        }
    }
}
