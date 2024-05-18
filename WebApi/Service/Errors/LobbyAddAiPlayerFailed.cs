using FluentResults;

namespace WebApi.Service.Errors;

public class LobbyAddAiPlayerFailed : Error
{
    public LobbyAddAiPlayerFailed(IEnumerable<IError> errors) : base($"Failed to add AI player to lobby. {string.Join(".", errors.Select(x => x.Message))}")
    {
    }
    
    public LobbyAddAiPlayerFailed(string message) : base($"Failed to add AI player to lobby. {message}")
    {
    }
}
