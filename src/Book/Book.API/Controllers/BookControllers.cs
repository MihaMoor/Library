using Book.API.Application.Queries.Book;
using Book.API.Application.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers;

public static class BookControllers
{
    public static RouteGroupBuilder MapBookQueriesApi(this RouteGroupBuilder app)
    {
        app.MapGet("/{id:Guid}", GetByIdAsync);
        app.MapGet("", Get);

        return app;
    }

    public static async Task<Results<Ok<BookViewModel>, NotFound<string>>> GetByIdAsync(Guid id, [FromServices] IBookQueries queries)
    {
        BookViewModel? book = await queries.GetBookAsync(id);

        return book == null
            ? TypedResults.NotFound(id.ToString())
            : TypedResults.Ok(book);
    }

    public static Results<Ok, NotFound> Get([FromServices] IBookQueries queries)
    {
        IAsyncEnumerable<BookViewModel> result = queries.GetBooksAsync();

        return TypedResults.Ok();
    }
}
