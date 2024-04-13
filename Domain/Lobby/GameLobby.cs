using Domain.Lobby.Errors;
using Domain.Shared;
using FluentResults;

namespace Domain.Lobby;

public class GameLobby(string id)
{
    private readonly List<Participant> _participants = new();

    public string Id { get; } = id;
    public IEnumerable<Participant> Participants => _participants.AsReadOnly();
    
    public Result Join(Player player)
    {
        if (_participants.Any(x => x.Player.Id == player.Id))
        {
            return Result.Fail(new PlayerAlreadyJoined());
        }

        if (_participants.Count == 0)
        {
            var participant = new Participant(player, Color.White);
            _participants.Add(participant);
            return Result.Ok();
        }

        if (_participants.Count == 1)
        {
            var participant = new Participant(player, Color.Black);
            _participants.Add(participant);
            return Result.Ok();
        }

        return Result.Fail(new GameQuotaReached());
    }
}