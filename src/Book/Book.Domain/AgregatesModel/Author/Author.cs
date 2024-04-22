using Shared.Core;

namespace Book.Domain.AgregatesModel;

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
        => CollectionWorker.Add(_publishingHouse, publishingHouse);

    public bool Equals(Author? author)
        => author != null &&
            Id == author.Id &&
            Name == author.Name &&
            Surname == author.Surname &&
            BirthYear == author.BirthYear;

    public override bool Equals(object? obj)
        => Equals(obj as Author);

    public override int GetHashCode()
        => base.GetHashCode();
}
