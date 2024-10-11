using aspire.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache")
    .WithLifetime(ContainerLifetime.Persistent);

var apiService = builder
    .AddProject<Projects.aspire_ApiService>("apiservice")
    .WithReference(cache);

builder.AddProject<Projects.aspire_Web>("webfrontend")
    .WithDumpDatabaseCommand()
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();