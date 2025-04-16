using Microsoft.Extensions.Hosting;
using DadJokeMCP;
using Microsoft.Extensions.DependencyInjection;

var builder = Host.CreateEmptyApplicationBuilder(settings: null);
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithTools<DadJokeTools>();

builder.Services.AddHttpClient();
builder.Services.AddSingleton<DadJokeService>();

await builder.Build().RunAsync();