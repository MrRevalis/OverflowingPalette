using OverflowingPalette.Application.Assembly;
using OverflowingPalette.Domain.Data;
using OverflowingPalette.Domain.Repositories.Base;

namespace OverflowingPalette.API.Extensions
{
    public static class Extensions
    {
        public static void AddAplicationServices(this IHostApplicationBuilder builder)
        {
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<IApplication>());

            builder.AddSqlServerDbContext<OverflowingPaletteDbContext>("overflowingPalette");

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        }

        public static void ApplyMigrations(this WebApplication app)
        {
            //using (var scope = app.Services.CreateScope())
            //{
            //    var dbContext = scope.ServiceProvider.GetRequiredService<OverflowingPaletteDbContext>();
            //    dbContext.Database.Migrate();
            //}
        }
    }
}
