using FluentResults;

namespace WebApi.Service.Errors;

public class GameNotFound(string gameId) : Error($"Game {gameId} not found")
{
    public string GameId { get; } = gameId;
}