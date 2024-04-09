using FluentResults;

namespace WebApi.Dto;

public record ErrorDto(IEnumerable<IError> Errors)
{
    public string Message => Errors.First().Message;
}