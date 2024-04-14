using Domain.Shared;
using FluentResults;

namespace Domain.Lobby.Errors;

public class PlayerAlreadyJoined(Player player) : Error($"Player {player.Id} already participates in the game");