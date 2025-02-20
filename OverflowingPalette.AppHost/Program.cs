using OverflowingPalette.Shared.Constants;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.OverflowingPalette_WebApp>(Constants.Configuration.WebApp);

builder.Build().Run();
