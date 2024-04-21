using Domain.Shared;

namespace Contracts.Players;

public record HeaderPlayer : Player
{
    public const string TypeValue = "API";
    public const string HeaderName = "PlayerId";
    public string Id { get; }
    public string Type => TypeValue;

    public HeaderPlayer(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"{nameof(Id)} cannot be empty");
        }
          
        Id = id;
    }
}   