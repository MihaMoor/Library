using Book.API.Application.Queries;
using Book.API.Extensions;
using Book.Domain.AgregatesModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers;

public static class BookControllers
{
    public static RouteGroupBuilder MapBookQueriesApi(this RouteGroupBuilder app)
    {
        app.MapGet("/", GetAsync);

        return app;
    }

    public static async IAsyncEnumerable<int> GetAsync(int[] numbers)
    {
        foreach (var item in numbers)
        {
            yield return await Task.Run(()=> item);
        }
    }
}
