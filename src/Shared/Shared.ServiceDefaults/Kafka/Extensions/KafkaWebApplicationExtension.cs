using Microsoft.AspNetCore.Builder;
using System.Text.Json;

namespace Shared.ServiceDefaults.Kafka;

public static class KafkaWebApplicationExtension
{
    public static WebApplicationBuilder AddProducer<T, K>(this WebApplicationBuilder builder, string section, Action<JsonSerializerOptions> options)
    {
        builder.Services.AddKafkaProducer<T, K>(
            builder.Configuration,
            section,
            x => x.SetValueSerializer(new KafkaSerializer<K>(options)
            ));

        return builder;
    }
}
