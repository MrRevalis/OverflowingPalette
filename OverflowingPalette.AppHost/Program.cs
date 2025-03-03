using OverflowingPalette.Shared.Constants;

var builder = DistributedApplication.CreateBuilder(args);

var webApi = builder.AddProject<Projects.OverflowingPalette_API>(Constants.Configuration.WebApi);

builder.AddProject<Projects.OverflowingPalette_WebApp>(Constants.Configuration.WebApp)
    .WaitFor(webApi)
    .WithReference(webApi);


builder.Build().Run();
