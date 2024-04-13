using Domain.Shared;
using FluentResults;

namespace Domain.Chessboard.Errors;

public class PlayerDoesNotParticipate(Player player) : Error($"Player {player.Id} does not participate in the game")
{
    
}