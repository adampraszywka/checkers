using FluentResults;

namespace WebApi.Service.Errors;

public class BoardPossibleMovesUnavailable : Error
{
    public BoardPossibleMovesUnavailable(IEnumerable<IError> errors): base($"Possible moves unavailable. {string.Join(".", errors.Select(x => x.Message))}")
    {
        CausedBy(errors);
    }
}