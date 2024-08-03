using Book.Domain.AggregatesModel;

namespace Book.UnitTests.DomainModels;

public partial class PublishingHouseTest
{
    [Theory]
    [MemberData(nameof(EqualHouses))]
    public void EqualsHouse(
        PublishingHouse house1,
        PublishingHouse house2,
        Func<PublishingHouse,
        PublishingHouse,
        bool> func,
        bool result)
        => Assert.Equal(func(house1, house2), result);

    [Theory]
    [MemberData(nameof(AddAuthorToHouse))]
    public void AddAuthors(
        PublishingHouse house,
        Author author,
        Action<PublishingHouse, Author> action,
        int expectedResult)
    {
        action(house, author);

        Assert.Equal(house.Authors.Count(), expectedResult);
    }
}
