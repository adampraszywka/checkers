using FluentResults;

namespace WebApi.Results;

public record ActionResult<T> where T : class
{
    public bool IsSuccessful { get; }
    public T Value => _value ?? throw new InvalidOperationException();
    public string ErrorMessage => _errorMessage ?? throw new InvalidOperationException();

    private readonly T? _value;
    private readonly string? _errorMessage;

    public static ActionResult<T> Success(T value) => new (value, null, true);
    public static ActionResult<T> Failed(string error) => new(null, error, false);
    public static ActionResult<T> FromErrors(IEnumerable<Error> errors) => new(null, string.Join(", ", errors.Select(x => x.Message)), false);

    private ActionResult(T? value, string? errorMessage, bool isSuccessful)
    {
        _value = value;
        _errorMessage = errorMessage;
        IsSuccessful = isSuccessful;
    }
}