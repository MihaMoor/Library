using Book.API.Application.Queries.Book;
using Book.Domain.AggregatesModel.BookAggregate;
using Book.Infrastructure;
using Book.Infrastructure.Repositories;

namespace Book.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void QueryServices(this WebApplicationBuilder builder) 
        => builder.Services.AddScoped<IBookQueries, BookQueries>();

    public static void RepositoryServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IBookRepository, BookRepository>();
    }
}
