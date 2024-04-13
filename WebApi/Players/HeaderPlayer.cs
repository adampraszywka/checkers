using Domain.Chessboard;
using Domain.Shared;

namespace WebApi.Players;

public record HeaderPlayer : Player, NotifiablePlayer
{
    public const string HeaderName = "PlayerId";

    public string Id { get; }

    public HeaderPlayer(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"{nameof(Id)} cannot be empty");
        }
          
        Id = id;
    }

    public Task Notify(BoardSnapshot snapshot)
    {
        Console.WriteLine($"Player {Id} notified about game state change!");
        return Task.CompletedTask; 
    }
}   