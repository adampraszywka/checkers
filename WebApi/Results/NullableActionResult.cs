using FluentResults;

namespace WebApi.Results;

public record NullableActionResult<T> where T : class
{
    public T? Value { get; }
    public string? ErrorMessage { get; }
    public bool IsSuccessful { get; }
    
    public static NullableActionResult<T> Success(T value) => new(value, null, true);
    public static NullableActionResult<T> Failed(string errorMessage) => new(null, errorMessage, false);
    public static NullableActionResult<T> FromErrors(IEnumerable<IError> errors) => new(null, errors.First().Message, false);
    private NullableActionResult(T? value, string? errorMessage, bool isSuccessful)
    {
        Value = value;
        ErrorMessage = errorMessage;
        IsSuccessful = isSuccessful;
    }
};