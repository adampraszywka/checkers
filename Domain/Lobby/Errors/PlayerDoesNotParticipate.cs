using Domain.Shared;
using FluentResults;

namespace Domain.Lobby.Errors;

public class PlayerDoesNotParticipate(Player player) : Error($"Player {player.Id} is not part of the lobby")
{
    
}