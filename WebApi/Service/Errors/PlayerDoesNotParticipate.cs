using Domain.Game;
using FluentResults;

namespace WebApi.Service.Errors;

public class PlayerDoesNotParticipate(Player player) : Error($"Player {player.Id} does not participate in the game")
{
    
}