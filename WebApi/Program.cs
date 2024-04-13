using Domain.Chessboard;
using MassTransit;
using WebApi.Repository;
using WebApi.Service;

const string devCors = "_devCors";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<BoardRepository, InMemoryBoardRepository>();
builder.Services.AddTransient<GameBoardFactory>();

builder.Services.AddMediator();

// For PoC development. Needs to be reworked later
builder.Services.AddCors(o =>
{
    o.AddPolicy(devCors,
        p => { p.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowAnyHeader(); });
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.UseCors(devCors);

app.Run();