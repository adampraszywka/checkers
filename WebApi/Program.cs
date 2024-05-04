using AIPlayers.MessageHub;
using AIPlayers.Players.AnthropicClaude;
using AIPlayers.Players.Dummy;
using AIPlayers.Players.OpenAIGpt4Turbo;
using Anthropic.SDK;
using Domain.Chessboard;
using Domain.Lobby;
using MassTransit;
using OpenAI.Extensions;
using WebApi.Consumers.AIInterface;
using WebApi.Consumers.Notification;
using WebApi.Hubs;
using WebApi.Players;
using WebApi.Repository;
using WebApi.Repository.InMemory;
using WebApi.Service;

const string devCors = "_devCors";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// InMemory repositories need to be declared as singleton
builder.Services.AddSingleton<BoardRepository, InMemoryBoardRepository>();
builder.Services.AddSingleton<InMemoryGameLobbyRepository>();

builder.Services.AddTransient<GameLobbyRepository>(x => x.GetRequiredService<InMemoryGameLobbyRepository>());
builder.Services.AddTransient<GameLobbyListRepository>(x => x.GetRequiredService<InMemoryGameLobbyRepository>());

builder.Services.AddScoped<PlayerFactory>();
builder.Services.AddScoped<BoardService>();
builder.Services.AddScoped<GameLobbyService>();

builder.Services.AddMassTransit(m =>
{
    m.AddConsumer<LobbyUpdatedConsumer>();
    m.AddConsumer<BoardUpdatedConsumer>();
    m.AddConsumer<MoveRequestedConsumer>();
    m.AddConsumer<AiPlayerStatusUpdatedConsumer>();

    m.AddConsumer<Hub>();
    
    m.AddConsumer<AiDummyPlayerConsumer>();
    m.AddConsumer<OpenAIGpt4TurboConsumer>();
    m.AddConsumer<AntrophicClaudePlayerConsumer>();

    m.UsingInMemory((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddSignalR();


builder.Services.AddTransient<APIAuthentication>(_ => new APIAuthentication(Environment.GetEnvironmentVariable("ANTHROPIC_API_KEY") ?? "INVALID"));
builder.Services.AddHttpClient<AnthropicClient>();

builder.Services.AddOpenAIService(x =>
{
    x.ApiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? "INVALID";
});

// For PoC development. Needs to be reworked later
builder.Services.AddCors(o =>
{
    o.AddPolicy(devCors,
        p =>
        {
            p.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyHeader()
                .AllowCredentials();
        });
});

var app = builder.Build();

app.MapGet("/ping", () => new {Result = "pong"});
app.MapHub<DashboardHub>("/hub_dashboard");
app.MapHub<BoardHub>("/hub_board");
app.MapHub<LobbyHub>("/hub_lobby");
app.MapHub<AiStatusHub>("/hub_aistatus");
app.MapControllers();
app.UseCors(devCors);
app.Run();