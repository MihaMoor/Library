namespace Book.UnitTests.DomainModels;

public class DomainModelTests
{
    private readonly AuthorTestData _authorTests = new();
    private readonly PublishingHouseTestData _publishedHouseTests = new();

    [Fact]
    public void EqulsAuthors1()
        => Assert.True(_authorTests.author1.Equals(_authorTests.author3));

    [Fact]
    public void EqulsAuthors2()
        => Assert.True(_authorTests.author1 == _authorTests.author3);

    [Fact]
    public void EqulsAuthors3()
        => Assert.True(_authorTests.author1 != _authorTests.author2);

    [Fact]
    public void EqualsPublishingHouse1()
        => Assert.True(_publishedHouseTests.publishingHouse1.Equals(_publishedHouseTests.publishingHouse3));

    [Fact]
    public void EqualsPublishingHouse2()
        => Assert.True(_publishedHouseTests.publishingHouse1 == _publishedHouseTests.publishingHouse3);

    [Fact]
    public void EqualsPublishingHouse3()
        => Assert.True(_publishedHouseTests.publishingHouse1 != _publishedHouseTests.publishingHouse2);
}