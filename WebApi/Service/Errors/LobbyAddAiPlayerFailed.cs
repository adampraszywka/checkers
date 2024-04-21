using FluentResults;

namespace WebApi.Service.Errors;

public class LobbyAddAiPlayerFailed(IEnumerable<IError> errors) : Error($"Failed to add AI player to lobby. {string.Join(".", errors.Select(x => x.Message))}");