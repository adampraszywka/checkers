using Domain.Shared;

namespace WebApi.Players;

public record ApiPlayer : Player
{
    public const string TypeValue = "API";
    public const string HeaderName = "PlayerId";
    public string Id { get; }
    public string Type => TypeValue;
    public bool Bot => false;

    public ApiPlayer(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"{nameof(Id)} cannot be empty");
        }
          
        Id = id;
    }
}   