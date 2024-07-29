using Book.Domain.AggregatesModel;

namespace Book.UnitTests.DomainModels;

public class AuthorTest
{
    [Theory]
    [MemberData(nameof(EqualAuthorsData))]
    public void EqualsAuthor(Author author1, Author author2, Func<Author, Author, bool> func, bool result)
        => Assert.Equal(func(author1, author2), result);

    [Theory]
    [MemberData(nameof(EqualsAuthorAsObjectData))]
    public void EqualsAuthorAsObject(Author author1, Author author2, bool result)
    {
        object obj = author2 as object;
        Assert.Equal(author1.Equals(obj), result);
    }

    [Theory]
    [MemberData(nameof(GetHashCodeData))]
    public void GetAuthorHashCode(Author author, int result)
        => Assert.Equal(author.GetHashCode(), result);

    [Theory]
    [MemberData(nameof(AddPublishingHouseToAuthorData))]
    public void AddPublishingHouse(Author author, PublishingHouse publishingHouse)
    {
        int count = author.HouseList.Count();
        author.AddPublishingHouse(publishingHouse);
        Assert.Equal(1, author.HouseList.Count() - count);
    }

    private readonly static Guid s_id = Guid.NewGuid();
    private readonly static DateTime s_dateTime = DateTime.Now;

    public static readonly TheoryData<Author, Author, Func<Author, Author, bool>, bool> EqualAuthorsData = new()
    {
        {
            new() { Id = s_id, Name = "test1", Surname = "test", BirthYear = s_dateTime },
            new() { Id = s_id, Name = "test1", Surname = "test", BirthYear = s_dateTime },
            (a, b) => a.Equals(b),
            true
        },
        {
            new() { Id = s_id, Name = "test2", Surname = "test", BirthYear = s_dateTime },
            new() { Id = s_id, Name = "test2", Surname = "test", BirthYear = s_dateTime },
            (a, b) => a == b,
            true
        },
        {
            new() { Id = s_id, Name = "test3", Surname = "test", BirthYear = s_dateTime },
            new() { Id = s_id, Name = "test1", Surname = "test1", BirthYear = s_dateTime },
            (a, b) => a != b,
            true
        },
        {
            null!,
            null!,
            (a,b) => a == b,
            true
        },
        {
            new() { Id = s_id, Name = "test5", Surname = "test", BirthYear = s_dateTime },
            new() { Id = s_id, Name = "test5", Surname = "test", BirthYear = s_dateTime },
            (a, b) => a.Equals(b),
            true
        },
    };

    public static readonly TheoryData<Author, Author, bool> EqualsAuthorAsObjectData = new()
    {
        {
            new() { Id = s_id, Name = "test1", Surname = "test", BirthYear = s_dateTime },
            new() { Id = s_id, Name = "test1", Surname = "test", BirthYear = s_dateTime },
            true
        },
        {
            new() { Id = s_id, Name = "test2", Surname = "test", BirthYear = s_dateTime },
            new() { Id = s_id, Name = "test22", Surname = "test1", BirthYear = s_dateTime },
            false
        },
        {
            new() { Id = s_id, Name = "test3", Surname = "test", BirthYear = s_dateTime },
            null!,
            false
        },
    };

    public static readonly TheoryData<Author, int> GetHashCodeData = new()
    {
        {
            new()
            {
                Id = Guid.Parse("46A9B344-72D1-44CC-BA07-6B79F5E95567"),
                Name = "test1",
                Surname = "test",
                BirthYear = DateTime.Parse("01.01.2000")
            },
            506500327
        }
    };

    public static readonly TheoryData<Author, PublishingHouse> AddPublishingHouseToAuthorData = new()
    {
        {
            new()
            {
                Id = s_id,
                Name = "test",
                Surname = "test",
                BirthYear = s_dateTime,
            },
            new()
            {
                Id = s_id,
                Name = "test",
                FoundationYear = s_dateTime,
            }
        }
    };
}
