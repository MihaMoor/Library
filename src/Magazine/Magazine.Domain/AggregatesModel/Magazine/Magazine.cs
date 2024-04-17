namespace Magazine.Domain.AggregatesModel;
public class Magazine
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime PublishDate { get; set; }
}
