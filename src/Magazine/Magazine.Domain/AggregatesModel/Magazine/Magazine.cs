namespace Magazine.Domain.AggregatesModel;
public class Magazine
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string? Description { get; set; }
    public DateTime PublishDate { get; init; }
    public PublishingHouse PublishingHouse { get; init; } = null!;
}
