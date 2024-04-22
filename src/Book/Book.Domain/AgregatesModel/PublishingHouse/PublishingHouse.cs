using Shared.Core;

namespace Book.Domain.AgregatesModel;

public class PublishingHouse : IEquatable<PublishingHouse>
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
        => CollectionWorker.Add(_authors, author);
    
    public bool Equals(PublishingHouse? publishingHouse)
    => publishingHouse != null &&
        publishingHouse.Id == Id &&
        publishingHouse.Name == Name &&
        publishingHouse.FoundationYear == FoundationYear;

    public override bool Equals(object? obj) => Equals(obj as PublishingHouse);

    public override int GetHashCode()
        => base.GetHashCode();
}
