using FluentResults;

namespace WebApi.Service.Errors;

public class LobbyNotFound(string lobbyId) : Error($"Lobby {lobbyId} not found")
{
    
}