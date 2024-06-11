using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Shared.ServiceDefaults.Kafka;

// ToDo: стоит подумать над тем, как сделать один метод, т.к. внутреннее наполнение одно и тоже.
/// <summary>
/// Generic расширение <see cref="IServiceCollection"/> для конфигурирования поставщиков и потребителей.
/// </summary>
public static class KafkaServiceExtension
{
    /// <summary>
    /// Расширение, добавляющее потребителя Kafka.
    /// </summary>
    /// <typeparam name="T">Тип ключа</typeparam>
    /// <typeparam name="K">Тип сообщения</typeparam>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <param name="configuration"><see cref="IConfiguration"/> для доступа к настройкам</param>
    /// <param name="section">Имя секции, из которой следует брать настройки.</param>
    /// <param name="options">Дополнительные настройки потребителя. Например добавление сериаллизаторов и дессериапизаторов для ключей и значений.</param>
    /// <returns>Модифицированный <see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddKafkaConsumer<T, K>(
        this IServiceCollection services,
        IConfiguration configuration,
        string section,
        Action<ConsumerBuilder<T, K>> options)
    {
        if (string.IsNullOrWhiteSpace(section) || configuration == null) return services;

        services.Configure<ConsumerConfig>(configuration.GetSection(section));
        services.AddSingleton(sp =>
        {
            IOptions<ConsumerConfig> config = sp.GetRequiredService<IOptions<ConsumerConfig>>();

            ConsumerBuilder<T, K> consumerBuilder = new(config.Value);
            options?.Invoke(consumerBuilder);

            return consumerBuilder.Build();
        });

        return services;
    }

    /// <summary>
    /// Расширение, добавляющее поставщика Kafka.
    /// </summary>
    /// <typeparam name="T">Тип ключа</typeparam>
    /// <typeparam name="K">Тип сообщения</typeparam>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <param name="configuration"><see cref="IConfiguration"/> для доступа к настройкам</param>
    /// <param name="section">Имя секции, из которой следует брать настройки.</param>
    /// <param name="options">Дополнительные настройки потребителя. Например добавление сериаллизаторов и дессериапизаторов для ключей и значений.</param>
    /// <returns>Модифицированный <see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddKafkaProducer<T, K>(
        this IServiceCollection services,
        IConfiguration configuration,
        string section,
        Action<ProducerBuilder<T, K>> options
        )
    {
        if (string.IsNullOrWhiteSpace(section) || configuration == null) return services;

        services.Configure<ProducerConfig>(configuration.GetSection(section));
        services.AddSingleton(sp =>
        {
            IOptions<ProducerConfig> config = sp.GetRequiredService<IOptions<ProducerConfig>>();

            ProducerBuilder<T, K> producerBuilder = new(config.Value);
            options?.Invoke(producerBuilder);

            return producerBuilder.Build();
        });

        return services;
    }
}
