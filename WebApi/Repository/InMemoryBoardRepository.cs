using Domain.Chessboard;
namespace WebApi.Repository;

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

    public Task Save(Board board)
    {
        _boards[board.Id] = board;
        return Task.CompletedTask;
    }
}