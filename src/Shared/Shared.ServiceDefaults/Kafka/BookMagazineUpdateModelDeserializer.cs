using Confluent.Kafka;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shared.ServiceDefaults.Kafka;

public class BookMagazineUpdateModelDeserializer : IDeserializer<BookMagazineUpdateModel>
{
    public BookMagazineUpdateModel Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
    {
        if (isNull) throw new ArgumentNullException();

        JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true,
        };
        options.Converters.Add(new JsonStringEnumConverter());

        BookMagazineUpdateModel entity = JsonSerializer.Deserialize<BookMagazineUpdateModel>(data, options)
            ?? throw new ArgumentNullException();

        return entity;
    }
}