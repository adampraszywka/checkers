using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Dto;

public record ActionResult<T> where T : class
{
    public T? Value { get; }
    public string? ErrorMessage { get; }
    public bool IsSuccessful { get; }
    
    public static ActionResult<T> Success(T value) => new(value, null, true);
    public static ActionResult<T> Failed(string errorMessage) => new(null, errorMessage, false);
    public static ActionResult<T> FromErrors(IEnumerable<IError> errors) => new(null, errors.First().Message, false);
    private ActionResult(T? value, string? errorMessage, bool isSuccessful)
    {
        Value = value;
        ErrorMessage = errorMessage;
        IsSuccessful = isSuccessful;
    }
};