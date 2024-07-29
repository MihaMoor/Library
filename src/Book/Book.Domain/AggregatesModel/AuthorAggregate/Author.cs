using Shared.Core;

namespace Book.Domain.AggregatesModel;

public class Author : IEquatable<Author>
{
    private readonly IList<PublishingHouse> _publishingHouse = [];

    public Guid Id { get; init; }

    public string Name { get; init; } = null!;

    public string Surname { get; set; } = null!;

    public DateTime BirthYear { get; init; }

    /// <summary>
    /// Список изданий, где публиковался автор.
    /// </summary>
    public IEnumerable<PublishingHouse> HouseList => [.. _publishingHouse];

    public void AddPublishingHouse(PublishingHouse publishingHouse)
        => CollectionOperations.Add(_publishingHouse, publishingHouse);

    public override bool Equals(object? obj)
        => Equals(obj as Author);

    public bool Equals(Author? author)
        => author is not null &&
           Id == author.Id &&
           Name == author.Name &&
           Surname == author.Surname &&
           BirthYear == author.BirthYear;

    // TODO: При каждом запросе на одних и тех же данных выдается разный результат!
    public override int GetHashCode()
        => HashCode.Combine(Id, Name, Surname);

    // ToDo: подумать как сделать красиво, т.к. точно такой же код есть в PublishingHouse.
    public static bool operator ==(Author? a, Author? b)
        => (a is null && b is null) ||
           (a is not null && a.Equals(b));

    public static bool operator !=(Author? a, Author? b)
        => !(a == b);
}
