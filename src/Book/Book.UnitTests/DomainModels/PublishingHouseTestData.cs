using Book.Domain.AggregatesModel;

namespace Book.UnitTests.DomainModels;

public class PublishingHouseTestData
{
    private readonly static Guid _id = Guid.NewGuid();
    private readonly static DateTime _dateTime = DateTime.Now;
    private readonly static AuthorTestData _authorTestData = new();
    private readonly static IEnumerable<Author> _authors = new List<Author>() { _authorTestData.author1, _authorTestData.author2, _authorTestData.author3 };

    public readonly PublishingHouse publishingHouse1 = new() { Id = _id, Name = "test1", FoundationYear = _dateTime };
    public readonly PublishingHouse publishingHouse2 = new() { Id = _id, Name = "test2", FoundationYear = _dateTime };
    public readonly PublishingHouse publishingHouse3 = new() { Id = _id, Name = "test1", FoundationYear = _dateTime };

    public PublishingHouseTestData()
    {
        foreach (Author author in _authors)
        {
            publishingHouse1 += author;
            publishingHouse3 += author;
        }
    }
}
