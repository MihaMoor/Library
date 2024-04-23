using Shared.Core;

namespace Book.Domain.AgregatesModel;

public class PublishingHouse : IEquatable<PublishingHouse?>
//: IEquatable<PublishingHouse>
{
    private readonly IList<Author> _authors = [];

    public Guid Id { get; init; }

    public string Name { get; set; } = null!;

    public DateTime FoundationYear { get; set; }

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
        EqualityComparer<IList<Author>>.Default.Equals(_authors, other._authors) &&
        Id.Equals(other.Id) &&
        Name == other.Name &&
        FoundationYear == other.FoundationYear;

    public override int GetHashCode()
        => HashCode.Combine(_authors, Id, Name, FoundationYear);

    public static bool operator ==(PublishingHouse? left, PublishingHouse? right)
        => EqualityComparer<PublishingHouse>.Default.Equals(left, right);

    public static bool operator !=(PublishingHouse? left, PublishingHouse? right)
        => !(left == right);
}
