using OverflowingPalette.WebApp.Services;
using OverflowingPalette.WebApp.Services.Interfaces;

namespace OverflowingPalette.WebApp.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            builder.Services.AddHttpClient<IGameService, GameService>(client =>
            {
                client.BaseAddress = new("https://localhost:7274");
            });
        }
    }
}
