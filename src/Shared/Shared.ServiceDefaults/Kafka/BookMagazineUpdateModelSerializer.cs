using Confluent.Kafka;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shared.ServiceDefaults.Kafka;

public class BookMagazineUpdateModelSerializer : ISerializer<BookMagazineUpdateModel>
{
    public byte[] Serialize(BookMagazineUpdateModel data, SerializationContext context)
    {
        ArgumentNullException.ThrowIfNull(data);

        JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true,
        };
        options.Converters.Add(new JsonStringEnumConverter());

        byte[] entity = JsonSerializer.SerializeToUtf8Bytes(data, options)
            ?? throw new ArgumentNullException();

        return entity;
    }
}
