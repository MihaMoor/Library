using Book.Domain.AggregatesModel;

namespace Book.UnitTests.DomainModels;

public class AuthorTestData
{
    private readonly static Guid Id = Guid.NewGuid();
    private readonly static DateTime dateTime = DateTime.Now;
    public readonly Author author1 = new() { Id = Id, Name = "author 1", Surname = "author1", BirthYear = dateTime };
    public readonly Author author2 = new() { Name = "author 2", Surname = "author2", BirthYear = DateTime.Parse("01.01.2001") };
    public readonly Author author3 = new() { Id = Id, Name = "author 1", Surname = "author1", BirthYear = dateTime };
}
