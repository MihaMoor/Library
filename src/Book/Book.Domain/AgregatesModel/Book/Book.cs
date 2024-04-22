namespace Book.Domain.AgregatesModel;

public class Book
{
    public Guid Id { get; init; }
    
    public string Title { get; init; } = null!;
    
    public string? Description { get; set; }
    
    public DateTime Year { get; init; }
    
    public Author Author { get; init; } = null!;
    
    public PublishingHouse PublishingHouse { get; init; } = null!;
}
