namespace MinimalAPIs.Services;

public class DataService(IHttpClientFactory httpClientFactory)
{
    private Dictionary<string, string> debugMe = new()
    {
        { "Key1", "Value1" },
        { "Key2", "Value2" },
        { "Key3", "Value3" },
    };

    private string cache = null!;

    public async Task<string> GetAsync()
    {
        debugMe.Add(Guid.NewGuid().ToString(), DateTimeOffset.UtcNow.ToString());

        using var client = httpClientFactory.CreateClient();

        var data = await client.GetAsync("https://google.com");

        return cache.ToUpperInvariant() + await data.Content.ReadAsStringAsync();
    }
}
