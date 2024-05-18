using Book.Domain.AggregatesModel;

namespace Book.UnitTests.DomainModels;

public class AuthorTest
{
    [Theory]
    [MemberData(nameof(EqualAuthors))]
    public void EqualsAuthor(Author author1, Author author2, Func<Author, Author, bool> func, bool result)
        => Assert.Equal(func(author1, author2), result);

    private readonly static Guid _id = Guid.NewGuid();
    private readonly static DateTime dateTime = DateTime.Now;
    public static readonly TheoryData<Author, Author, Func<Author, Author, bool>, bool> EqualAuthors = new()
    {
        {
            new() { Id = _id, Name = "test", Surname = "test", BirthYear = dateTime },
            new() { Id = _id, Name = "test", Surname = "test", BirthYear = dateTime },
            (a, b) => a.Equals(b),
            true
        },
        {
            new() { Id = _id, Name = "test", Surname = "test", BirthYear = dateTime },
            new() { Id = _id, Name = "test", Surname = "test", BirthYear = dateTime },
            (a, b) => a == b,
            true
        },
        {
            new() { Id = _id, Name = "test", Surname = "test", BirthYear = dateTime },
            new() { Id = _id, Name = "test1", Surname = "test1", BirthYear = dateTime },
            (a, b) => a != b,
            true
        }
    };
}
