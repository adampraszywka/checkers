using FluentResults;

namespace Domain.Lobby.Errors;

public class NotEnoughPlayers(int playerCount, int expectedPlayers) : Error($"Cannot close lobby with {playerCount}. {expectedPlayers} players are required to start game")
{
    
}