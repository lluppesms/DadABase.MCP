using System.Text.Json.Serialization;

namespace DadJokeMCP;

[JsonSerializable(typeof(List<DadJoke>))]
internal sealed partial class DadJokeContext : JsonSerializerContext
{

}
public class JokeList
{
    public List<DadJoke> Jokes { get; set; }

    public JokeList()
    {
        Jokes = [];
    }
}

public class DadJoke
{
    public string JokeCategoryTxt { get; set; }
    public string JokeTxt { get; set; }
    public string Attribution { get; set; }
    public string ImageTxt { get; set; }
    public DadJoke()
    {
        JokeTxt = string.Empty;
        JokeCategoryTxt = string.Empty;
        Attribution = string.Empty;
        ImageTxt = string.Empty;
    }
    public DadJoke(string jokeTxt)
    {
        JokeTxt = jokeTxt;
        JokeCategoryTxt = string.Empty;
        Attribution = string.Empty;
        ImageTxt = string.Empty;
    }
    public DadJoke(string jokeTxt, string jokeCategoryTxt)
    {
        JokeTxt = jokeTxt;
        JokeCategoryTxt = jokeCategoryTxt;
        Attribution = string.Empty;
        ImageTxt = string.Empty;
    }
    public DadJoke(string jokeTxt, string jokeCategoryTxt, string imageTxt)
    {
        JokeTxt = jokeTxt;
        JokeCategoryTxt = jokeCategoryTxt;
        Attribution = string.Empty;
        ImageTxt = imageTxt;
    }

    public DadJoke(string jokeTxt, string jokeCategoryTxt, string imageTxt, string attribution)
    {
        JokeTxt = jokeTxt;
        JokeCategoryTxt = jokeCategoryTxt;
        Attribution = attribution;
        ImageTxt = imageTxt;
    }
}
