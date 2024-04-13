using FluentResults;

namespace Domain.Lobby.Errors;

public class PlayerAlreadyJoined() : Error("Given player has already join the game");