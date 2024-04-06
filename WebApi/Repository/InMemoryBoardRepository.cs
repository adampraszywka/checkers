using Domain;
using Domain.Configurations.Classic;

namespace WebApi.Repository;

public class InMemoryBoardRepository : BoardRepository
{
    private readonly Dictionary<string, Board> _boards = new();
    
    public Task<Board> Get(string id)
    {
        if (!_boards.ContainsKey(id))
        {
            var board = new Board(ClassicConfiguration.NewBoard());
            _boards[id] = board;
            return Task.FromResult(board);
        }
        
        return Task.FromResult(_boards[id]);
    }

    public Task Save(Board board)
    {
        return Task.CompletedTask;
    }
}