using Domain.Chessboard;
using Jitbit.Utils;
using Microsoft.Extensions.Options;
using WebApi.Settings;

namespace WebApi.Repository.InMemory;

public class InMemoryBoardRepository(IOptions<InMemoryStorageSettings> settings) : BoardRepository
{
    private readonly FastCache<string, Board> _boards = new();
    private readonly TimeSpan _timeToLive = settings.Value.TimeToLive;

    public Task<Board?> Get(string id)
    {
        if (_boards.TryGet(id, out var board))
        {
            return Task.FromResult<Board?>(board);
        }

        return Task.FromResult<Board?>(null);
    }

    public Task Save(Board gameBoard)
    {
        _boards.AddOrUpdate(gameBoard.Id, gameBoard, _timeToLive);
        return Task.CompletedTask;
    }
}