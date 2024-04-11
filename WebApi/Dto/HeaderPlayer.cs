using Domain.Game;

namespace WebApi.Dto;

public record HeaderPlayer : Player
{
    public const string HeaderName = "PlayerId";

    public HeaderPlayer(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException($"{nameof(Id)} cannot be empty");

        Id = id;
    }

    public string Id { get; }
}