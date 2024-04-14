using FluentResults;

namespace WebApi.Service.Errors;

public class LobbyCreationFailed(IEnumerable<IError> errors) : Error($"Lobby creation failed. {string.Join(".", errors.Select(x => x.Message))}")
{
    
}