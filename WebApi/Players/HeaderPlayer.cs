using Domain.Shared;

namespace WebApi.Players;

public record HeaderPlayer : Player
{
    public const string HeaderName = "PlayerId";

    public string Id { get; }
    public string Type => "API";

    public HeaderPlayer(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"{nameof(Id)} cannot be empty");
        }
          
        Id = id;
    }
}   