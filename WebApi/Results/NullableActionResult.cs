using FluentResults;

namespace WebApi.Results;

public record NullableActionResult<T> where T : class
{
    public T? Value { get; }
    public string? ErrorMessage { get; }
    public string? ErrorCode { get; }
    public bool IsSuccessful { get; }
    
    public static NullableActionResult<T> Success(T value) => new(value, null, null, true);
    public static NullableActionResult<T> Failed(string errorMessage, string errorCode) => new(null, errorMessage, errorCode, false);
    public static NullableActionResult<T> FromErrors(IEnumerable<IError> errors, string errorCode) => new(null, errors.First().Message, errorCode, false);
    private NullableActionResult(T? value, string? errorMessage, string? errorCode, bool isSuccessful)
    {
        Value = value;
        ErrorMessage = errorMessage;
        IsSuccessful = isSuccessful;
        ErrorCode = errorCode;
    }
};