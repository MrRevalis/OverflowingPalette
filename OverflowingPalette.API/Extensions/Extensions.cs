using OverflowingPalette.Application.Assembly;

namespace OverflowingPalette.API.Extensions
{
    public static class Extensions
    {
        public static void AddAplicationServices(this IHostApplicationBuilder builder)
        {
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<IApplication>());
        }
    }
}
