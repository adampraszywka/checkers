using FluentResults;

namespace WebApi.Service.Errors;

public class PossibleMovesUnavailable : Error
{
    public PossibleMovesUnavailable(IEnumerable<IError> errors): base($"Possible moves unavailable. {string.Join(".", errors.Select(x => x.Message))}")
    {
        CausedBy(errors);
    }
}