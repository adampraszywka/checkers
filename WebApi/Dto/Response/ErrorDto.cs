using FluentResults;

namespace WebApi.Dto.Response;

public record ErrorDto(IEnumerable<IError> Errors)
{
    public string Message => Errors.First().Message;
}