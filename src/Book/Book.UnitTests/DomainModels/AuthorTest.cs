using Book.Domain.AggregatesModel;

namespace Book.UnitTests.DomainModels;

public partial class AuthorTest
{
    [Theory]
    [MemberData(nameof(EqualAuthorsData))]
    public void EqualsAuthor(Author author1, Author author2, Func<Author, Author, bool> func, bool result)
        => Assert.Equal(func(author1, author2), result);

    [Theory]
    [MemberData(nameof(EqualsAuthorAsObjectData))]
    public void EqualsAuthorAsObject(Author author1, Author author2, bool result)
    {
        object obj = author2;

        Assert.Equal(author1.Equals(obj), result);
    }

    [Theory]
    [ClassData(typeof(AuthorGetHashCode))]
    public void GetAuthorHashCode(Author author)
        => Assert.Equal(author.GetHashCode(), author.GetHashCode());

    [Theory]
    [MemberData(nameof(AddPublishingHouseToAuthorData))]
    public void AddPublishingHouse(Author author, PublishingHouse publishingHouse)
    {
        int count = author.HouseList.Count();
        author.AddPublishingHouse(publishingHouse);

        Assert.Equal(1, author.HouseList.Count() - count);
    }
}
