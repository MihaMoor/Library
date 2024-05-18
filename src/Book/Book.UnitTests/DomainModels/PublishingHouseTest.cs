using Book.Domain.AggregatesModel;

namespace Book.UnitTests.DomainModels;

public class PublishingHouseTest
{
    [Theory]
    [MemberData(nameof(EqualHouses))]
    public void EqualsHouse(PublishingHouse house1, PublishingHouse house2, Func<PublishingHouse, PublishingHouse, bool> func, bool result)
        => Assert.Equal(func(house1, house2), result);

    private readonly static Guid _id = Guid.NewGuid();
    private readonly static DateTime _dateTime = DateTime.Now;
    public static readonly TheoryData<PublishingHouse, PublishingHouse, Func<PublishingHouse, PublishingHouse, bool>, bool> EqualHouses = new()
    {
        {
            //House1
            new([
                new() { Id = _id, Name = "test", Surname = "test", BirthYear = _dateTime },
                new() { Id = _id, Name = "test", Surname = "test", BirthYear = _dateTime },
                ])
            {
                Id = _id,
                Name = "test",
                FoundationYear = _dateTime
            },
            //House2
            new([
                new() { Id = _id, Name = "test", Surname = "test", BirthYear = _dateTime },
                new() { Id = _id, Name = "test", Surname = "test", BirthYear = _dateTime },
                ])
            {
                Id = _id,
                Name = "test",
                FoundationYear = _dateTime
            },
            //Func
            (a, b) => a.Equals(b),
            //Expected result
            true
        },
        {
            //House1
            new([
                new() { Id = _id, Name = "test", Surname = "test", BirthYear = _dateTime },
                new() { Id = _id, Name = "test", Surname = "test", BirthYear = _dateTime },
                ])
            {
                Id = _id,
                Name = "test",
                FoundationYear = _dateTime
            },
            //House2
            new([
                new() { Id = _id, Name = "test", Surname = "test", BirthYear = _dateTime },
                new() { Id = _id, Name = "test", Surname = "test", BirthYear = _dateTime },
                ])
            {
                Id = _id,
                Name = "test",
                FoundationYear = _dateTime
            },
            //Func
            (a, b) => a == b,
            //Expected result
            true
        },
        {
            // House1
            new([
                new() { Id = _id, Name = "test", Surname = "test", BirthYear = _dateTime },
                new() { Id = _id, Name = "test", Surname = "test", BirthYear = _dateTime },
                ])
            {
                Id = _id,
                Name = "test",
                FoundationYear = _dateTime
            },
            // House2
            new([
                new() { Id = _id, Name = "test", Surname = "test", BirthYear = _dateTime },
                new() { Id = _id, Name = "test", Surname = "test", BirthYear = _dateTime },
                ])
            {
                Id = _id,
                Name = "test1",
                FoundationYear = _dateTime
            },
            //Func
            (a, b) => a != b,
            //Expected result
            true
        }
    };
}
