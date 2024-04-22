namespace Magazine.Domain.AggregatesModel;

public class Magazine
{
    public Guid Id { get; init; }
    
    public string Name { get; init; } = null!;
    
    public string? Description { get; set; }
    
    public DateTime PublishDate { get; init; }
    
    public PublishingHouse PublishingHouse { get; init; } = null!;

    public bool Equals(Magazine? magazine)
        => magazine != null &&
            magazine.Id == Id &&
            magazine.Name == Name &&
            magazine.PublishDate == PublishDate;

    public override bool Equals(object? obj) 
        => base.Equals(obj) ? true : Equals(obj as Magazine);
}
