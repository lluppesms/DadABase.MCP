using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;

namespace DadJokeMCP;

[McpServerToolType]
public sealed class DadJokeTools
{
    private readonly DadJokeService DadJokeService;

    public DadJokeTools(DadJokeService DadJokeService)
    {
        this.DadJokeService = DadJokeService;
    }

    [McpServerTool, Description("Get a list of DadJokes.")]
    public async Task<string> GetDadJokes()
    {
        var DadJokes = await DadJokeService.GetDadJokes();
        return JsonSerializer.Serialize(DadJokes);
    }

    [McpServerTool, Description("Get a DadJoke by name.")]
    public async Task<string> GetDadJoke([Description("The name of the DadJoke to get details for")] string name)
    {
        var DadJoke = await DadJokeService.GetDadJoke(name);
        return JsonSerializer.Serialize(DadJoke);
    }
}
