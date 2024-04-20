namespace Book.Domain.AgregatesModel;

public class PublishingHouse
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
    {
        if (author == null) return;

        if (HasAuthor(author)) return;
        _authors.Add(author);
    }
    private bool HasAuthor(Author author)
    {
        if (_authors.Count == 0) return false;

        foreach (Author innerAuthor in _authors)
        {
            if (innerAuthor.Equals(author)) return true;
        }

        return false;
    }
}
