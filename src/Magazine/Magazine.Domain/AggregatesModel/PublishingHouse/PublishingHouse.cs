namespace Magazine.Domain.AggregatesModel;

public class PublishingHouse
{
    protected readonly IList<Magazine> MagazinesRegistry = [];

    public Guid Id { get; init; }

    public string Name { get; init; } = null!;

    public DateTime FoundationYear { get; init; }

    /// <summary>
    /// Список журналов, которые публиковались в данном издании.
    /// </summary>
    public IReadOnlyCollection<Magazine> Magazines => MagazinesRegistry.AsReadOnly();

    protected virtual bool HasMagazine(Magazine magazine)
    {
        if (MagazinesRegistry.Count == 0 || magazine == null) return false;

        foreach (Magazine innerMagazine in MagazinesRegistry)
        {
            if (innerMagazine.Equals(magazine)) return true;
        }

        return false;
    }

    public virtual void AddMagazine(Magazine magazine)
    {
        if (magazine == null || HasMagazine(magazine)) return;
        MagazinesRegistry.Add(magazine);
    }

    public virtual void RemoveMagazine(Magazine magazine)
    {
        if (magazine == null || !HasMagazine(magazine)) return;
        MagazinesRegistry.Remove(magazine);
    }

    public override bool Equals(object? obj)
        => Equals(obj as PublishingHouse);

    public bool Equals(PublishingHouse? other)
        => other != null &&
            Id == other.Id &&
            Name == other.Name &&
            FoundationYear == other.FoundationYear;

    public override int GetHashCode()
        => HashCode.Combine(MagazinesRegistry, Id, Name, FoundationYear);

    public static bool operator ==(PublishingHouse? a, PublishingHouse? b)
        => (a is null && b is null) ||
           (a is not null && a.Equals(b));

    public static bool operator !=(PublishingHouse? a, PublishingHouse? b)
        => !(a == b);
}
