namespace Magazine.Domain.AggregatesModel;

public class PublishingHouse
{
    private readonly IList<Magazine> _magazines = [];
    
    public Guid Id { get; init; }
    
    public string Name { get; init; } = null!;
    
    public DateTime FoundationYear { get; init; }
    
    public IReadOnlyCollection<Magazine> Magazines => _magazines.AsReadOnly();

    public void AddMagazine(Magazine magazine)
    {
        if (magazine == null) return;
        if (HasMagazine(magazine)) return;
        _magazines.Add(magazine);
    }
    
    private bool HasMagazine(Magazine magazine)
    {
        if (_magazines.Count == 0) return false;
        foreach (Magazine innerMagazine in _magazines)
        {
            if (innerMagazine.Equals(magazine)) return true;
        }

        return false;
    }
}
