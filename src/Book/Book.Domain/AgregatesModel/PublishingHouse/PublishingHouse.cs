namespace Book.Domain.AgregatesModel;
public class PublishingHouse
{
    public Guid Id { get; init; }
    public string Name { get; set; } = null!;
    public DateTime FoundationYear { get; set; }
    /// <summary>
    /// Список авторов, которые публиковались в данном издании.
    /// </summary>
    public IList<Author> Authors { get; set; } = [];
}
