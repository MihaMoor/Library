using Book.API.Resources.Localizations;
using Confluent.Kafka;
using Shared.ServiceDefaults.Kafka;

using DeleteMessage = Confluent.Kafka.Message<string, Shared.ServiceDefaults.Kafka.BookMagazineDeleteModel>;
using DeleteResult = Confluent.Kafka.DeliveryResult<string, Shared.ServiceDefaults.Kafka.BookMagazineDeleteModel>;
using UpdateMessage = Confluent.Kafka.Message<string, Shared.ServiceDefaults.Kafka.BookMagazineUpdateModel>;
using UpdateResult = Confluent.Kafka.DeliveryResult<string, Shared.ServiceDefaults.Kafka.BookMagazineUpdateModel>;

namespace Book.API.Application.Commands;

/// <summary>
/// Предоставляет методы для отправки сообщений.
/// </summary>
public static class KafkaMessageProducer
{
    /// <summary>
    /// Отправляет сообщение в топик <see cref="TopicNames.BookMagazineUpdateTopic"/> с моделью <see cref="BookMagazineUpdateModel"/>.
    /// </summary>
    /// <param name="id">Id</param>
    /// <param name="entityType">Тип сущности <see cref="BookMagazineEntityType"/></param>
    /// <param name="geometry">Геометрия сущности</param>
    /// <param name="type">Тип операции <see cref="BookMagazineOperationType"/></param>
    /// <param name="producer">Поставщик Kafka</param>
    /// <param name="logger">Логер</param>
    public static async void UpdateEntity(
        Guid id,
        BookMagazineEntityType entityType,
        IList<Author> authors,
        BookMagazineOperation type,
        IProducer<string, BookMagazineUpdateModel> producer,
        ILogger logger)
    {
        try
        {
            UpdateResult dr = await producer.ProduceAsync(TopicNames.BookMagazineUpdateTopic,
                new UpdateMessage
                {
                    Value = new(id, entityType, authors, type),
                });

            logger.LogInformation(string.Format(
                Localization.KafkaMessageProducer_Produce,
                entityType,
                id,
                TopicNames.BookMagazineUpdateTopic));
        }
        catch (ProduceException<string, BookMagazineUpdateModel> ex)
        {
            logger.LogError(ex.Message);
        }
    }

    /// <summary>
    /// Отправляет сообщение в топик <see cref="TopicNames.BookMagazineDeleteTopic"/> с моделью <see cref="BookMagazineDeleteModel"/>.
    /// </summary>
    /// <param name="id">Id</param>
    /// <param name="entityType">Тип сущности <see cref="BookMagazineEntityType"/></param>
    /// <param name="producer">Поставщик Kafka</param>
    /// <param name="logger">Логер</param>
    public static async void DeleteEntity(
        Guid id,
        BookMagazineEntityType entityType,
        IProducer<string, BookMagazineDeleteModel> producer,
        ILogger logger)
    {
        try
        {
            DeleteResult dr = await producer.ProduceAsync(TopicNames.BookMagazineDeleteTopic,
                new DeleteMessage
                {
                    Value = new BookMagazineDeleteModel(id, entityType),
                });

            logger.LogInformation(string.Format(
                Localization.KafkaMessageProducer_Produce,
                entityType,
                id,
                TopicNames.BookMagazineDeleteTopic));
        }
        catch (ProduceException<string, BookMagazineDeleteModel> ex)
        {
            logger.LogError(ex.Message);
        }
    }
}
