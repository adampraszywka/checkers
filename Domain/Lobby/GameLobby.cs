using Domain.Chessboard;
using Domain.Lobby.Errors;
using Domain.Shared;
using FluentResults;

namespace Domain.Lobby;

public class GameLobby(string id, string name)
{
    private const int RequiredPlayerCount = 2;
    
    private readonly List<Participant> _participants = new();
    private string? _gameId = null;
    
    public string Id { get; } = id;
    public string Name { get; } = name;
    public int MaxPlayers { get; } = RequiredPlayerCount;
    public string? GameId => _gameId;
    
    public IEnumerable<Participant> Participants => _participants.AsReadOnly();
    
    public Result Join(Player player)
    {
        if (_gameId is not null)
        {
            return Result.Fail(new AlreadyClosed());
        }
        
        if (_participants.Any(x => x.Player.Id == player.Id))
        {
            return Result.Fail(new PlayerAlreadyJoined(player));
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

    public Result<Board> Close(Player player, BoardFactory factory)    
    {
        if (_participants.All(x => x.Player.Id != player.Id))
        {
            return Result.Fail(new PlayerDoesNotParticipate(player));
        }
        
        if (_gameId is not null)
        {
            return Result.Fail(new AlreadyClosed());
        }       
        
        if (_participants.Count != RequiredPlayerCount)
        {
            return Result.Fail(new NotEnoughPlayers(_participants.Count, RequiredPlayerCount));
        }

        var board = factory.Create(_participants);
        _gameId = board.Id;
        return Result.Ok(board); 
    }
}