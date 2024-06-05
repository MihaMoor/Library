using Shared.Core;

namespace Book.Domain.AggregatesModel;

public class PublishingHouse : IEquatable<PublishingHouse?>
{
    private readonly IList<Author> _authors = [];

    public Guid Id { get; init; }

    public string Name { get; set; } = null!;

    public DateTime FoundationYear { get; set; }

    public PublishingHouse() { }

    public PublishingHouse(IEnumerable<Author> authors)
    {
        foreach (Author author in authors)
        {
            _authors.Add(author);
        }
    }

    /// <summary>
    /// Список авторов, которые публиковались в данном издании.
    /// </summary>
    public IEnumerable<Author> Authors => [.. _authors];

    public void AddAuthor(Author author)
        => CollectionOperations.Add(_authors, author);

    public override bool Equals(object? obj)
        => Equals(obj as PublishingHouse);

    public bool Equals(PublishingHouse? other) 
        => other is not null &&
           _authors.SequenceEqual(other._authors) &&
           Id.Equals(other.Id) &&
           Name == other.Name &&
           FoundationYear == other.FoundationYear;

    public override int GetHashCode()
        => HashCode.Combine(_authors, Id, Name, FoundationYear);

    public static bool operator ==(PublishingHouse? a, PublishingHouse? b)
        => (a is null && b is null) ||
           (a is not null && a.Equals(b));

    public static bool operator !=(PublishingHouse? a, PublishingHouse? b)
        => !(a == b);

    public static PublishingHouse operator +(PublishingHouse house, Author author)
    {
        if (author != null) house.AddAuthor(author);
        return house;
    }
}
