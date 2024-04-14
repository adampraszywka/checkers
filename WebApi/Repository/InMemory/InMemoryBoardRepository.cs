using Domain.Chessboard;

namespace WebApi.Repository.InMemory;

public class InMemoryBoardRepository : BoardRepository
{
    private readonly Dictionary<string, Board> _boards = new();
    
    public Task<Board?> Get(string id)
    {
        if (_boards.TryGetValue(id, out var board))
        {
            return Task.FromResult<Board?>(board);
        }

        return Task.FromResult<Board?>(null);
    }

    public Task Save(Board gameBoard)
    {
        _boards[gameBoard.Id] = gameBoard;
        return Task.CompletedTask;
    }
}