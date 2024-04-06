using FluentResults;

namespace WebApi.Dto;

public record ErrorDto(IError Error)
{
    public string Message => Error.Message;
}