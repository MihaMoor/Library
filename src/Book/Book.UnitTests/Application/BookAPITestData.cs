using Book.API.Extensions;
using Book.Domain.AggregatesModel;
using Book.Infrastructure;
using System.Collections;

namespace Book.UnitTests.Application;

public partial class BookApiTest
{
    public static readonly TheoryData<Guid, BookContext, Domain.AggregatesModel.Book> BookApiGetExistingBookById = new()
    {
        {
            Guid.Parse("46A9B344-72D1-44CC-BA07-6B79F5E95567"),
            new InMemoryBookDB().Context,
            new Domain.AggregatesModel.Book()
            {
                Id = Guid.Parse("46A9B344-72D1-44CC-BA07-6B79F5E95567"),
                Title = "Test1",
                Year = DateTime.Parse("01.01.2001"),
                Author = new()
                {
                    Id = Guid.Parse("46A9B344-72D1-44CC-BA07-6B79F5E95567"),
                    BirthYear = DateTime.Parse("01.01.1991"),
                    Name = "Test",
                    Surname = "Testovich"
                },
                PublishingHouse = new()
                {
                    Id = Guid.Parse("46A9B344-72D1-44CC-BA07-6B79F5E95567"),
                    FoundationYear = DateTime.Parse("01.01.2000"),
                    Name = "Test house"
                }
            }
        },
    };

    public static readonly TheoryData<Guid, BookContext> BookApiGetFaildBookById = new()
        {
            { Guid.NewGuid(), new InMemoryBookDB().Context },
            { Guid.NewGuid(), new InMemoryBookDB().Context },
            { Guid.NewGuid(), new InMemoryBookDB().Context },
            { Guid.NewGuid(), new InMemoryBookDB().Context }
        };
}

public class BookApiGetBooks : IEnumerable<object[]>
{
    private readonly PublishingHouse _publishingHouse = new()
    {
        Id = Guid.NewGuid(),
        Name = "Test",
        FoundationYear = DateTime.Parse("01.01.2000")
    };

    private readonly Author _author = new()
    {
        Id = Guid.NewGuid(),
        Name = "Test",
        Surname = "Author",
        BirthYear = DateTime.Now,
    };

    private readonly IList<Domain.AggregatesModel.Book> _books;

    public BookContext Context { get; private set; }

    public BookApiGetBooks()
    {
        Context = new InMemoryBookDB().Context;
        _books = [];
    }

    public int SeedBooks()
    {
        for (int i = 0; i < 10; i++)
        {
            Domain.AggregatesModel.Book book = new()
            {
                Id = Guid.NewGuid(),
                Title = $"Test {i}",
                Year = DateTime.Now,
                Author = _author,
                PublishingHouse = _publishingHouse
            };

            _books.Add(book);
            Context.Books.Add(book);
        }

        _author.AddPublishingHouse(_publishingHouse);
        _publishingHouse.AddAuthor(_author);

        Context.Authors.Add(_author);
        Context.PublishingHouses.Add(_publishingHouse);

        return Context.SaveChanges();
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        foreach (API.Application.ViewModels.BookViewModel? book in Context.Books.Select(x => x.ToViewModel()))
        {
            yield return new object[] { book };
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
