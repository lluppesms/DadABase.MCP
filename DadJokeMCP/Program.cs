using Microsoft.Extensions.Hosting;
using DadJokeMCP;
using Microsoft.Extensions.DependencyInjection;

var djs = new DadJokeService();
var joke = await djs.GetDadJoke();
Console.WriteLine(joke.JokeTxt);

var builder = Host.CreateEmptyApplicationBuilder(settings: null);
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithTools<DadJokeTools>();

//builder.Services.AddHttpClient();
builder.Services.AddSingleton<DadJokeService>();

await builder.Build().RunAsync();