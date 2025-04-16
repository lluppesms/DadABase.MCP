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

    [McpServerTool, Description("Get a random Dad Jokes.")]
    public async Task<string> GetDadJoke()
    {
        var dadJoke = await DadJokeService.GetDadJoke();
        return JsonSerializer.Serialize(dadJoke);
    }

    [McpServerTool, Description("Get a list of Dad Joke by category.")]
    public async Task<string> GetDadJokesByCategory([Description("The name of the Dad Joke Category to get a list of jobs for")] string name)
    {
        var dadJokes = await DadJokeService.GetDadJokesByCategory(name);
        return JsonSerializer.Serialize(dadJokes);
    }

    [McpServerTool, Description("Get a list of Dad Joke categories.")]
    public async Task<string> GetDadJokeCategories()
    {
        var categories = await DadJokeService.GetDadJokeCategories();
        return JsonSerializer.Serialize(categories);
    }
}
