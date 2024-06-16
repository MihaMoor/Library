namespace Shared.ServiceDefaults.Kafka;

public record BookMagazineUpdateModel(
    Guid Id,
    BookMagazineEntityType EntityType,
    IList<Author> Authors,
    BookMagazineOperation Operation
    );

public record Author(
    Guid Id,
    string FullName
    );