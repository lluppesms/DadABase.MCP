using DadJokeMCP;
using System.Text.Json;

namespace DadJokeMCPSSE;

public class DadJokeService
{
    private static readonly string sourceFileName = "Data/Jokes.json";
    private static JokeList JokeData = new();
    private static List<string> JokeCategories = [];

    public DadJokeService()
    {
        // load up the jokes into memory
        using (var r = new StreamReader(sourceFileName))
        {
            var json = r.ReadToEnd();
            JokeData = JsonSerializer.Deserialize<JokeList>(json) ?? new JokeList();
        }

        // select distinct categories from JokeData
        JokeCategories = JokeData.Jokes.Select(joke => joke.JokeCategoryTxt).Distinct().Order().ToList();
    }

    public static async Task<DadJoke> GetDadJoke()
    {
        _ = await Task.FromResult(true);
        var joke = JokeData.Jokes[Random.Shared.Next(0, JokeData.Jokes.Count)];
        return joke ?? new DadJoke("No jokes here!");
    }

    public static async Task<List<DadJoke>> GetDadJokesByCategory(string categoryName)
    {
        _ = await Task.FromResult(true);
        var jokesInCategory = JokeData.Jokes
            .Where(joke => JokeCategories.Any(category => category == joke.JokeCategoryTxt))
            .ToList();
        return jokesInCategory;
    }

    public static async Task<List<string>> GetDadJokeCategories()
    {
        _ = await Task.FromResult(true);
        return JokeCategories;
    }
}
