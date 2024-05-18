using AIPlayers.Algorithms.AnthropicClaude;
using AIPlayers.Algorithms.Dummy;
using AIPlayers.Algorithms.OpenAIGpt4o;
using AIPlayers.Algorithms.OpenAIGpt4Turbo;
using AIPlayers.Extensions;
using AIPlayers.MessageHub;
using AIPlayers.Players;
using AIPlayers.Repository;
using Anthropic.SDK;
using Domain.Chessboard;
using Domain.Lobby;
using MassTransit;
using Microsoft.Extensions.Options;
using OpenAI;
using OpenAI.Interfaces;
using OpenAI.Managers;
using WebApi.Consumers.AIInterface;
using WebApi.Consumers.Notification;
using WebApi.Hubs;
using WebApi.Players;
using WebApi.Repository;
using WebApi.Repository.InMemory;
using WebApi.Service;
using WebApi.Settings;

const string devCors = "_devCors";

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOptionsWithValidateOnStart<AnthropicSettings>()
    .ValidateDataAnnotations()
    .Bind(builder.Configuration.GetSection(AnthropicSettings.Key));

builder.Services.AddOptionsWithValidateOnStart<OpenAISettings>()
    .ValidateDataAnnotations()
    .Bind(builder.Configuration.GetSection(OpenAISettings.Key));

builder.Services.AddControllers();

// InMemory repositories need to be declared as singleton
builder.Services.AddSingleton<AIPlayerRepository, InMemoryAIPlayerRepository>();
builder.Services.AddSingleton<BoardRepository, InMemoryBoardRepository>();
builder.Services.AddSingleton<InMemoryGameLobbyRepository>();

builder.Services.AddTransient<GameLobbyRepository>(x => x.GetRequiredService<InMemoryGameLobbyRepository>());
builder.Services.AddTransient<GameLobbyListRepository>(x => x.GetRequiredService<InMemoryGameLobbyRepository>());

builder.Services.AddScoped<BoardService>();
builder.Services.AddScoped<GameLobbyService>();

builder.Services.AddAIPlayers();

builder.Services.AddMassTransit(m =>
{
    m.AddConsumer<LobbyUpdatedConsumer>();
    m.AddConsumer<BoardUpdatedConsumer>();
    m.AddConsumer<MoveRequestedConsumer>();
    m.AddConsumer<AiPlayerStatusUpdatedConsumer>();

    m.AddConsumer<Hub>();

    m.UsingInMemory((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddSignalR();

builder.Services.AddTransient<APIAuthentication>(x => 
    new APIAuthentication(x.GetRequiredService<IOptions<AnthropicSettings>>().Value.ApiKey));
builder.Services.AddHttpClient<AnthropicClient>();

builder.Services.AddOptions<OpenAiOptions>()
    .Configure<IOptions<OpenAISettings>>((options, settings) =>
    {
        options.ApiKey = settings.Value.ApiKey;
        options.ProviderType = ProviderType.OpenAi;
    });
builder.Services.AddHttpClient<IOpenAIService, OpenAIService>();

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