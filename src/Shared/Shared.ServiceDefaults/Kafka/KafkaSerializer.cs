using Confluent.Kafka;
using System.Text.Json;

namespace Shared.ServiceDefaults.Kafka;

public class KafkaSerializer<T>(Action<JsonSerializerOptions> serializeOptions) : ISerializer<T>, IDeserializer<T>
{
    public byte[] Serialize(T data, SerializationContext context)
    {
        ArgumentNullException.ThrowIfNull(data);

        JsonSerializerOptions options = new();
        serializeOptions?.Invoke(options);

        byte[] entity = JsonSerializer.SerializeToUtf8Bytes(data, options)
            ?? throw new ArgumentNullException("Serialize object is null");

        return entity;
    }

    /// <inheritdoc/>
    public virtual T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
    {
        if (isNull) throw new ArgumentNullException("Value is null");

        JsonSerializerOptions options = new();
        serializeOptions?.Invoke(options);

        T entity = JsonSerializer.Deserialize<T>(data, options)
            ?? throw new ArgumentNullException("Deserialize object is null");

        return entity;
    }
}