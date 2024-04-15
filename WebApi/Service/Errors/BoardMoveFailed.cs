using FluentResults;

namespace WebApi.Service.Errors;

public class BoardMoveFailed : Error 
{
    public BoardMoveFailed(IEnumerable<IError> errors) : base($"Move failed. {string.Join(".", errors.Select(x => x.Message))}")
    {
        CausedBy(errors);
    }
}