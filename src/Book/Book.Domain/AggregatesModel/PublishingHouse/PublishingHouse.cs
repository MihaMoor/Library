using Shared.Core;

namespace Book.Domain.AggregatesModel;

public class PublishingHouse : IEquatable<PublishingHouse?>
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
    {
        if(other is null) return false;

        var hasMatching = (from author in _authors
                          from innerAuthor in other.Authors
                          where author == innerAuthor
                          select new { }).Any();

        return other is not null &&
               hasMatching &&
               Equals(_authors, other._authors) &&
               Id.Equals(other.Id) &&
               Name == other.Name &&
               FoundationYear == other.FoundationYear;
    }

    public override int GetHashCode()
        => HashCode.Combine(_authors, Id, Name, FoundationYear);

    public static bool operator ==(PublishingHouse? a, PublishingHouse? b)
        => (a is null && b is null) ||
           (a is not null && a.Equals(b));

    public static bool operator !=(PublishingHouse? a, PublishingHouse? b)
        => !(a == b);
}
