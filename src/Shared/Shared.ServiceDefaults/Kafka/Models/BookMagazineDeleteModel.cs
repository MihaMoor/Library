namespace Shared.ServiceDefaults.Kafka;

public record BookMagazineDeleteModel(
    Guid Id,
    BookMagazineEntityType EntityType
    );