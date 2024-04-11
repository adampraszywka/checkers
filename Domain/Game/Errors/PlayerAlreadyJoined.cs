using FluentResults;

namespace Domain.Game.Errors;

public class PlayerAlreadyJoined() : Error("Given player has already join the game");