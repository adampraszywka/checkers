using Domain.Chessboard;
using Domain.Lobby;
using MassTransit;
using WebApi.Consumers.Notification;
using WebApi.Hubs;
using WebApi.Messages.Notification;
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

builder.Services.AddScoped<BoardService>();
builder.Services.AddScoped<GameLobbyService>();

builder.Services.AddMassTransit(m =>
{
    m.AddConsumer<LobbyUpdatedConsumer>();
    
    m.UsingInMemory((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddSignalR();

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

app.MapGet("/", () => "Hello World!");
app.MapHub<DashboardHub>("/hub_dashboard");
app.MapControllers();
app.UseCors(devCors);

app.Run();