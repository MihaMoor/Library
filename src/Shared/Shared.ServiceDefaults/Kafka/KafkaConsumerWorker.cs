using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Shared.ServiceDefaults.Kafka;

/// <summary>
/// Базовый класс, предоставляющий метод для асинхронного запуска потребителя.
/// </summary>
/// <typeparam name="T">Тип ключа</typeparam>
/// <typeparam name="K">Тип сообщения</typeparam>
/// <param name="consumer">Реализация потребителя</param>
/// <param name="logger">Логер</param>
/// <param name="topicName">Название топика для подписки</param>
public abstract class KafkaConsumerWorker<T, K>(
    IConsumer<T, K> consumer,
    ILogger<KafkaConsumerWorker<T, K>> logger,
    string topicName)
    : BackgroundService
{
    /// <summary>
    /// Потребитель.
    /// </summary>
    protected IConsumer<T, K> Consumer { get; } = consumer;

    /// <inheritdoc/>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        => await Task.Run(() => Consuming(stoppingToken), stoppingToken);

    private async Task Consuming(CancellationToken stoppingToken)
    {
        Consumer.Subscribe(topicName);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await Handle(stoppingToken);
            }
            catch (Exception ex)
            {
                // Все ошибки ловятся для того, что бы сервис продолжал штатно работать.
                logger.LogError(ex, ex.Message);
            }
        }

        Consumer.Close();
        Consumer.Dispose();
    }

    /// <summary>
    /// Обработчик событий из Kafka.
    /// </summary>
    /// <param name="stoppingToken">Токен для завершения <see cref="Task"/></param>
    /// <returns></returns>
    public abstract Task Handle(CancellationToken stoppingToken);
}
