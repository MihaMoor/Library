namespace Book.Domain.AgregatesModel;
public class Author
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public string Surname { get; set; } = null!;
    public DateTime BirthYear { get; init; }
    /// <summary>
    /// Список изданий, где публиковался автор.
    /// </summary>
    public IList<PublishingHouse> HouseList { get; } = [];
}
