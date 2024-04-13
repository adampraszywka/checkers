using Domain.Chessboard.Pieces;
using Domain.Game.Errors;
using FluentResults;

namespace Domain.Game;

public class GameInstance(string id, string boardId)
{
    private readonly List<Participant> _participants = new(2);
    public string Id { get; } = id;
    public string BoardId { get; } = boardId;
    public IEnumerable<Participant> Participants => _participants.AsReadOnly();

    public Result Join(Player player)
    {
        if (_participants.Any(x => x.Id == player.Id))
        {
            return Result.Fail(new PlayerAlreadyJoined());
        }

        if (_participants.Count == 0)
        {
            var participant = new Participant(player.Id, Color.White);
            _participants.Add(participant);
            return Result.Ok();
        }

        if (_participants.Count == 1)
        {
            var participant = new Participant(player.Id, Color.Black);
            _participants.Add(participant);
            return Result.Ok();
        }

        return Result.Fail(new GameQuotaReached());
    }

    public Participant? Get(Player player)
    {
        return _participants.FirstOrDefault(x => x.Id == player.Id);
    }

    public Participation Participation(Player player)
    {
        return new Participation(Get(player));
    }
}