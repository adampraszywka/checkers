using Domain.Errors.Game;
using Domain.Pieces;
using FluentResults;

namespace Domain;

public class Game(string id, string boardId)
{
    public string Id { get; } = id;
    public string BoardId { get; } = boardId;

    private readonly List<Participant> _participants = new(2);

    public Result Join(Player player)
    {
        if (DoesParticipate(player))
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

    public Participant? Get(Player player) => _participants.FirstOrDefault(x => x.Id == player.Id);

    public bool DoesParticipate(Player player) => _participants.Any(x => x.Id == player.Id);
}