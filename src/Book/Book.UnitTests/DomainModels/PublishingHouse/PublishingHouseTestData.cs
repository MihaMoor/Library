using Book.Domain.AggregatesModel;
using System.Collections;

namespace Book.UnitTests.DomainModels;

public partial class PublishingHouseTest
{
    private readonly static Guid s_id = Guid.NewGuid();
    private readonly static DateTime s_dateTime = DateTime.Now;
    private readonly static Author s_author = new() { Id = Guid.NewGuid(), Name = "test", Surname = "test", BirthYear = DateTime.Now };

    public static readonly TheoryData<PublishingHouse, PublishingHouse, Func<PublishingHouse, PublishingHouse, bool>, bool> EqualHouses = new()
    {
        #region Equal
        {
            //House1
            new([
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                ])
            {
                Id = s_id,
                Name = "test",
                FoundationYear = s_dateTime
            },
            //House2
            new([
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                ])
            {
                Id = s_id,
                Name = "test",
                FoundationYear = s_dateTime
            },
            //Func
            (a, b) => a.Equals(b),
            //Expected result
            true
        },
        {
            //House1
            new([
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                ])
            {
                Id = s_id,
                Name = "test",
                FoundationYear = s_dateTime
            },
            //House2
            new([
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                ])
            {
                Id = s_id,
                Name = "test",
                FoundationYear = s_dateTime
            },
            //Func
            (a, b) => a == b,
            //Expected result
            true
        },
        #endregion
        
        #region ==
        {
            //House1
            new([
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                ])
            {
                Id = s_id,
                Name = "test",
                FoundationYear = s_dateTime
            },
            //House2
            new([
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                ])
            {
                Id = s_id,
                Name = "test",
                FoundationYear = s_dateTime
            },
            //Func
            (a, b) => a == b,
            //Expected result
            true
        },
        {
            //House1
            new([
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                ])
            {
                Id = s_id,
                Name = "test",
                FoundationYear = s_dateTime
            },
            //House2
            null!,
            //Func
            (a, b) => a == b,
            //Expected result
            false
        },
        {
            //House1
            null!,
            //House2
            null!,
            //Func
            (a, b) => a == b,
            //Expected result
            true
        },
        #endregion
        
        #region !=
        {
            //House1
            new([
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                ])
            {
                Id = s_id,
                Name = "test",
                FoundationYear = s_dateTime
            },
            //House2
            new([
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                ])
            {
                Id = s_id,
                Name = "test",
                FoundationYear = s_dateTime
            },
            //Func
            (a, b) => a != b,
            //Expected result
            false
        },
        {
            // House1
            new([
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                ])
            {
                Id = s_id,
                Name = "test",
                FoundationYear = s_dateTime
            },
            // House2
            new([
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                ])
            {
                Id = s_id,
                Name = "test1",
                FoundationYear = s_dateTime
            },
            //Func
            (a, b) => a != b,
            //Expected result
            true
        },
        {
            // House1
            new([
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                ])
            {
                Id = s_id,
                Name = "test",
                FoundationYear = s_dateTime
            },
            // House2
            null!,
            //Func
            (a, b) => a != b,
            //Expected result
            true
        },
        {
            // House1
            null!,
            // House2
            null!,
            //Func
            (a, b) => a != b,
            //Expected result
            false
        },
        #endregion

    };

    public static readonly TheoryData<PublishingHouse, Author, Action<PublishingHouse, Author>, int> AddAuthorToHouse = new()
    {
        #region AddAuthor
        {
            new([
                new() { Id = Guid.NewGuid(), Name = "test", Surname = "test", BirthYear = DateTime.Now },
                new(){ Id = Guid.NewGuid(), Name = "test", Surname = "test", BirthYear = DateTime.Now }])
            {
                Id = Guid.NewGuid(),
                Name = "test",
                FoundationYear= DateTime.Now,
            },
            new() { Id = Guid.NewGuid(), Name = "test", Surname = "test", BirthYear = DateTime.Now },
            (h, a) => h.AddAuthor(a),
            3
        },
        {
            new([
                new() { Id = Guid.NewGuid(), Name = "test", Surname = "test", BirthYear = DateTime.Now },
                new(){ Id = Guid.NewGuid(), Name = "test", Surname = "test", BirthYear = DateTime.Now }])
            {
                Id = Guid.NewGuid(),
                Name = "test",
                FoundationYear= DateTime.Now,
            },
            null!,
            (h, a) => h.AddAuthor(a),
            2
        },
        {
            new([
                new() { Id = Guid.NewGuid(), Name = "test", Surname = "test", BirthYear = DateTime.Now },
                s_author])
            {
                Id = Guid.NewGuid(),
                Name = "test",
                FoundationYear= DateTime.Now,
            },
            s_author,
            (h, a) => h.AddAuthor(a),
            2
        },
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "test",
                FoundationYear= DateTime.Now,
            },
            s_author,
            (h, a) => h.AddAuthor(a),
            1
        },
        #endregion

        #region +=
        {
            new([
                new() { Id = Guid.NewGuid(), Name = "test", Surname = "test", BirthYear = DateTime.Now },
                new(){ Id = Guid.NewGuid(), Name = "test", Surname = "test", BirthYear = DateTime.Now }])
            {
                Id = Guid.NewGuid(),
                Name = "test",
                FoundationYear= DateTime.Now,
            },
            new() { Id = Guid.NewGuid(), Name = "test", Surname = "test", BirthYear = DateTime.Now },
            (h, a) => h += a,
            3
        },
        {
            new([
                new() { Id = Guid.NewGuid(), Name = "test", Surname = "test", BirthYear = DateTime.Now },
                new(){ Id = Guid.NewGuid(), Name = "test", Surname = "test", BirthYear = DateTime.Now }])
            {
                Id = Guid.NewGuid(),
                Name = "test",
                FoundationYear= DateTime.Now,
            },
            null!,
            (h, a) => h += a,
            2
        },
        {
            new([
                new() { Id = Guid.NewGuid(), Name = "test", Surname = "test", BirthYear = DateTime.Now },
                s_author])
            {
                Id = Guid.NewGuid(),
                Name = "test",
                FoundationYear= DateTime.Now,
            },
            s_author,
            (h, a) => h += a,
            2
        },
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "test",
                FoundationYear= DateTime.Now,
            },
            s_author,
            (h, a) => h += a,
            1
        },
        #endregion
    };

    public static readonly TheoryData<PublishingHouse, PublishingHouse, bool> EqualsHouseAsObjectData = new()
    {
        {
            //House1
            new([
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                ])
            {
                Id = s_id,
                Name = "test",
                FoundationYear = s_dateTime
            },
            //House2
            new([
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                ])
            {
                Id = s_id,
                Name = "test",
                FoundationYear = s_dateTime
            },
            true
        },
        {
            //House1
            new([
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                ])
            {
                Id = s_id,
                Name = "test",
                FoundationYear = s_dateTime
            },
            //House2
            new([
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = DateTime.Now },
                ])
            {
                Id = s_id,
                Name = "test",
                FoundationYear = s_dateTime
            },
            //Expected result
            false
        },
        {
            //House1
            new([
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                ])
            {
                Id = s_id,
                Name = "test",
                FoundationYear = s_dateTime
            },
            //House2
            new([
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                new() { Id = s_id, Name = "test1", Surname = "test", BirthYear = s_dateTime },
                ])
            {
                Id = s_id,
                Name = "test",
                FoundationYear = s_dateTime
            },
            //Expected result
            false
        },
        {
            //House1
            new([
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                new() { Id = s_id, Name = "test", Surname = "test", BirthYear = s_dateTime },
                ])
            {
                Id = s_id,
                Name = "test",
                FoundationYear = s_dateTime
            },
            //House2
            null!,
            //Expected result
            false
        },
    };
}

public class HouseGetHashCode : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new object[]
            {
                new PublishingHouse()
                {
                    Id = Guid.NewGuid(),
                    Name = $"test{i}",
                    FoundationYear = DateTime.Now
                }
            };
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}