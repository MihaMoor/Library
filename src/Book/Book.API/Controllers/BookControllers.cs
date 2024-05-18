using Book.API.Application.Queries.Book;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers;

public static class BookControllers
{
    public static RouteGroupBuilder MapBookQueriesApi(this RouteGroupBuilder app)
    {
        app.MapGet("/{id:Guid}", GetAsync);

        return app;
    }

    public static async Task<IResult> GetAsync(Guid id, [FromServices] IBookQueries queries)
        => await queries.GetBookAsync(id);
}
