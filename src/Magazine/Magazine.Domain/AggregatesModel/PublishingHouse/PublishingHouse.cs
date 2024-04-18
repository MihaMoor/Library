namespace Magazine.Domain.AggregatesModel;
public class PublishingHouse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public DateTime FoundationYear { get; init; }
}
