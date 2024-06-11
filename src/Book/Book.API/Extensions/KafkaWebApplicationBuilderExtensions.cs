using Book.API.BackgroundWorkers;
using Shared.ServiceDefaults.Kafka;

namespace Book.API.Extensions;

public static class KafkaWebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddKafka(this WebApplicationBuilder builder)
        => builder
            .AddConsumers()
            .AddWorkers()
            .AddProducers();

    private static WebApplicationBuilder AddConsumers(this WebApplicationBuilder builder)
    {
        builder.Services.AddKafkaConsumer<string, BookMagazineUpdateModel>(
            builder.Configuration,
            "KafkaConsumer",
            x => x.SetValueDeserializer(new BookMagazineUpdateModelDeserializer())
            );

        return builder;
    }

    private static WebApplicationBuilder AddWorkers(this WebApplicationBuilder builder)
    {
        builder.Services.AddHostedService<BookMagazineUpdateWorker>();

        return builder;
    }

    private static WebApplicationBuilder AddProducers(this WebApplicationBuilder builder)
    {
        builder.Services.AddKafkaProducer<string, BookMagazineUpdateModel>(
            builder.Configuration,
            "KafkaProducer",
            x => x.SetValueSerializer(new BookMagazineUpdateModelSerializer())
            );

        return builder;
    }
}
