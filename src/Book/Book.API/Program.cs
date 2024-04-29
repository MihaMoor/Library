using Book.API.Application.Queries;
using Book.API.Controllers;
using Book.Infrastructure;
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

        MapGroup(app);

        app.Run();
    }

    private static void MapGroup(WebApplication app)
    {
        app.MapGroup("/api/book").MapBookQueriesApi();
    }
}
