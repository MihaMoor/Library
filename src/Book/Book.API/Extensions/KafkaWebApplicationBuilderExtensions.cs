using Book.API.BackgroundWorkers;
using Confluent.Kafka;
using Shared.ServiceDefaults.Kafka;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Book.API.Extensions;

public static class KafkaWebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddKafka(this WebApplicationBuilder builder)
        => builder
            .AddConsumer<Null, BookMagazineUpdateModel>((options) =>
            {
                options.PropertyNameCaseInsensitive = true;
                options.Converters.Add(new JsonStringEnumConverter());
            })
            .AddProducer<Null, BookMagazineUpdateModel>("KafkaProducer", (options) =>
            {
                options.PropertyNameCaseInsensitive = true;
                options.Converters.Add(new JsonStringEnumConverter());
            })
            .AddWorkers();

    private static WebApplicationBuilder AddConsumer<T, K>(this WebApplicationBuilder builder, Action<JsonSerializerOptions> options)
    {
        builder.Services.AddKafkaConsumer<T, K>(
            builder.Configuration,
            "KafkaConsumer",
            x => x.SetValueDeserializer(new KafkaSerializer<K>(options))
        );

        return builder;
    }

    private static WebApplicationBuilder AddWorkers(this WebApplicationBuilder builder)
    {
        builder.Services.AddHostedService<BookMagazineUpdateWorker>();

        return builder;
    }
}
