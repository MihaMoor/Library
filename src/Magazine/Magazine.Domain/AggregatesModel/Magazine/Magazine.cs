namespace Magazine.Domain.AggregatesModel;

public class Magazine
{
    public Guid Id { get; init; }

    public string Name { get; init; } = null!;

    public string? Description { get; set; }

    public DateTime PublishDate { get; init; }

    public PublishingHouse PublishingHouse { get; init; } = null!;

    public override bool Equals(object? obj)
        => Equals(obj as Magazine);

    public bool Equals(Magazine? magazine)
        => magazine != null &&
            magazine.Id == Id &&
            magazine.Name == Name &&
            magazine.PublishDate == PublishDate;

    public override int GetHashCode()
        => HashCode.Combine(Id, Name, Description, PublishDate, PublishingHouse);

    public static bool operator ==(Magazine? a, Magazine? b)
        => (a is null && b is null) ||
           (a is not null && a.Equals(b));

    public static bool operator !=(Magazine? a, Magazine? b)
        => !(a == b);
}
