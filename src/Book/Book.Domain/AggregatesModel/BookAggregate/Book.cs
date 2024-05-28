namespace Book.Domain.AggregatesModel;

public class Book : IAggregateRoot
{
    public Guid Id { get; init; }
    
    public string Title { get; init; } = null!;
    
    public string? Description { get; set; }
    
    public DateTime Year { get; init; }
    
    public Author Author { get; init; } = null!;
    
    public PublishingHouse PublishingHouse { get; init; } = null!;
}
