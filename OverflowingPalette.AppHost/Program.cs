using static OverflowingPalette.Shared.Constants.Constants;

var builder = DistributedApplication.CreateBuilder(args);

var database = builder.AddSqlServer("sql")
    //.WithDataVolume()
    .AddDatabase("overflowingPalette");

var webApi = builder.AddProject<Projects.OverflowingPalette_API>(Configuration.WebApi)
    .WithReference(database)
    .WaitFor(database);

builder.AddProject<Projects.OverflowingPalette_WebApp>(Configuration.WebApp)
    .WaitFor(webApi)
    .WithReference(webApi);


builder.Build().Run();
