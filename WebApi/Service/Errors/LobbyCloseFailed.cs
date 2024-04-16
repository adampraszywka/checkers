using FluentResults;

namespace WebApi.Service.Errors;

public class LobbyCloseFailed(IEnumerable<IError> errors) : Error($"Lobby close failed. {string.Join(".", errors.Select(x => x.Message))}")
{
    
}