namespace Book.Domain.AgregatesModel;

public class Author : IEquatable<Author>
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string Surname { get; set; } = null!;
    public DateTime BirthYear { get; init; }
    /// <summary>
    /// Список изданий, где публиковался автор.
    /// </summary>
    public IList<PublishingHouse> HouseList { get; } = [];

    public bool Equals(Author? author)
        => author != null &&
            Id == author.Id &&
            Name == author.Name &&
            Surname == author.Surname &&
            BirthYear == author.BirthYear;

}
