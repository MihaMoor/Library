namespace Magazine.Domain.AggregatesModel;
public class PublishingHouse
{
    public Guid Id { get; init; }
    public string Name { get; set; } = null!;
    public DateTime FoundationYear { get; set; }
}
