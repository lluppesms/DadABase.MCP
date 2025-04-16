using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace DadJokeMCP;

public class DadJokeService
{
    private readonly HttpClient httpClient;
    public DadJokeService(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient();
    }

    List<DadJoke> DadJokeList = new();
    public async Task<List<DadJoke>> GetDadJokes()
    {
        if (DadJokeList?.Count > 0)
            return DadJokeList;

        // Online
        var response = await httpClient.GetAsync("https://www.montemagno.com/DadJokes.json");
        if (response.IsSuccessStatusCode)
        {
            DadJokeList = await response.Content.ReadFromJsonAsync(DadJokeContext.Default.ListDadJoke) ?? [];
        }

        DadJokeList ??= [];

        return DadJokeList;
    }

    public async Task<DadJoke?> GetDadJoke(string name)
    {
        var DadJokes = await GetDadJokes();
        return DadJokes.FirstOrDefault(m => m.Name?.Equals(name, StringComparison.OrdinalIgnoreCase) == true);
    }
}

public partial class DadJoke
{
    public string? Name { get; set; }
    public string? Location { get; set; }
    public string? Details { get; set; }
    public string? Image { get; set; }
    public int Population { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

[JsonSerializable(typeof(List<DadJoke>))]
internal sealed partial class DadJokeContext : JsonSerializerContext {

}