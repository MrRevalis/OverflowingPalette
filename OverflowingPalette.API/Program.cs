using OverflowingPalette.API.Extensions;
using OverflowingPalette.Domain.Data;
using OverflowingPalette.ServiceDefaults;

namespace OverflowingPalette.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddAplicationServices();
        builder.AddServiceDefaults();

        // Add services to the container.
        builder.Services.AddAuthorization();

        builder.Services.AddControllers();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<OverflowingPaletteDbContext>();
                context.Database.EnsureCreated();
            }
        }

        app.ApplyMigrations();
        app.AddAplicationServices();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Swagger"));

        app.MapControllers();

        app.Run();
    }
}
