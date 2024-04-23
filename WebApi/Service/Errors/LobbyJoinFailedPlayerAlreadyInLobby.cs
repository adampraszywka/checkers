using FluentResults;

namespace WebApi.Service.Errors;

public class LobbyJoinFailedPlayerAlreadyInLobby() : Error("Player is already in a lobby");