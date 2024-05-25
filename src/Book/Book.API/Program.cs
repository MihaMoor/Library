using Book.API.Application.Queries;
using Book.API.Controllers;
using Book.Domain.AggregatesModel.BookAggregate;
using Book.Infrastructure;
using Book.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Book.API;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContextFactory<BookContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("BookContext"))
        );

        builder.Services.AddScoped<IBookRepository, BookRepository>();
        builder.QueryServices();

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseHttpsRedirection();

        app.UseAuthorization();

        MapGroups(app);

        app.Run();
    }

    private static void MapGroups(WebApplication app)
    {
        app.MapGroup("/api/book").MapBookQueriesApi();
    }
}
