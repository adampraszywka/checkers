using WebApi.Dto;
using WebApi.Repository;

const string devCors = "_devCors";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<BoardRepository, InMemoryBoardRepository>();

// For PoC development. Needs to be reworked later
builder.Services.AddCors(o =>
{
    o.AddPolicy(devCors, p => p.WithOrigins("http://localhost:4200"));
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/board", async (BoardRepository repository) =>
{
    var board = await repository.Get();
    var snapshot = board.Snapshot;
    return new BoardDto(snapshot);
});

app.UseCors(devCors);

app.Run();