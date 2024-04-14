using FluentResults;

namespace WebApi.Service.Errors;

public class LobbyJoinFailed(IEnumerable<IError> errors) : Error($"Lobby join failed. {string.Join(".", errors.Select(x => x.Message))}")
{
    
}