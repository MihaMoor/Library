using Book.API.Application.Queries.Book;
using Book.API.Application.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers;

public static class BookControllers
{
    public static RouteGroupBuilder MapBookQueriesApi(this RouteGroupBuilder app)
    {
        app.MapGet("/{id:Guid}", GetAsync);

        return app;
    }

    public static async Task<Results<Ok<BookViewModel>, NotFound<string>>> GetAsync(Guid id, [FromServices] IBookQueries queries)
    {
        BookViewModel? book = await queries.GetBookAsync(id);

        return book == null
            ? TypedResults.NotFound(id.ToString())
            : TypedResults.Ok(book);
    }
}
