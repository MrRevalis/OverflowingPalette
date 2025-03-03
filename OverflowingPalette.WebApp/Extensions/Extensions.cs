using OverflowingPalette.WebApp.Services;

namespace OverflowingPalette.WebApp.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            builder.Services.AddHttpClient<GameService>(client =>
            {
                client.BaseAddress = new("https://localhost:7274");
            });
        }
    }
}
