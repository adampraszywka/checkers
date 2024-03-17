using Domain;
using Microsoft.AspNetCore.Mvc;
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

app.MapPost("/move", async (BoardRepository repo, [FromBody] MoveDto request) =>
{
    var board = await repo.Get();

    var from = new Position(request.From.Row, request.From.Column);
    var to = new Position(request.To.Row, request.To.Column);

    var result = board.Move(from, to);

    if (result.IsFailed)
    {
        throw new Exception();
    }
    
    repo.Save(board);

    return new BoardDto(board.Snapshot);
});
    

app.UseCors(devCors);

app.Run();