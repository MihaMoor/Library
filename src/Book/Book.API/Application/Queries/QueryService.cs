using Book.API.Application.Queries.Book;

namespace Book.API.Application.Queries;

public static class QueryService
{
    public static void QueryServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IBookQueries, BookQueries>();

        builder.Services.AddControllersWithViews();
    }
}
