using FluentResults;

namespace Domain.Errors.Game;

public class PlayerAlreadyJoined() : Error("Given player has already join the game")
{
    
}