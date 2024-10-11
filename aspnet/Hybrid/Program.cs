using Microsoft.Extensions.Caching.Hybrid;

var builder = WebApplication.CreateBuilder(args);

#pragma warning disable EXTEXP0018 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
builder.Services.AddHybridCache();
#pragma warning restore EXTEXP0018 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

var app = builder.Build();

app.MapGet("/", async (HybridCache cache, CancellationToken token) =>
{
    string data = await cache.GetOrCreateAsync("cacheKey",
        async cancellationToken => await RetrieveAsync(),
        cancellationToken: token
    );

    return data;
});

app.Run();

Task<string> RetrieveAsync()
{
    return Task.FromResult($"Hello NDC {DateTimeOffset.UtcNow}");
}