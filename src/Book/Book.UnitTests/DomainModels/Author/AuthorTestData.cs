using Book.Domain.AggregatesModel;
using System.Collections;

namespace Book.UnitTests.DomainModels;

public partial class AuthorTest
{

    private readonly static Guid s_id = Guid.NewGuid();
    private readonly static DateTime s_dateTime = DateTime.Now;

    public static readonly TheoryData<Author, Author, Func<Author, Author, bool>, bool> EqualAuthorsData = new()
    {
        #region Equal
        {
            new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
            new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
            (a, b) => a.Equals(b),
            true
        },
        #endregion
        #region ==
        {
            new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
            new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
            (a, b) => a == b,
            true
        },
        {
            new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
            null!,
            (a, b) => a == b,
            false
        },
        {
            null!,
            null!,
            (a, b) => a == b,
            true
        },
        #endregion
        #region !=
        {
            new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
            new() { Id = s_id, Name = "test1", Surname = "test1", BirthYear = s_dateTime },
            (a, b) => a != b,
            true
        },
        {
            new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
            null!,
            (a, b) => a != b,
            true
        },
        {
            null!,
            null!,
            (a, b) => a != b,
            false
        },
        #endregion
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

public class AuthorGetHashCode : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new object[]
            {
                new Author()
                {
                    Id = Guid.NewGuid(),
                    Name = $"test{i}",
                    Surname = "test",
                    BirthYear = DateTime.Now
                }
            };
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
