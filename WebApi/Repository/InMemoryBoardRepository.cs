using Domain.Chessboard;
using Domain.Chessboard.Configurations.Classic;
using Domain.Repository;

namespace WebApi.Repository;

public class InMemoryBoardRepository : BoardRepository
{
    private readonly Dictionary<string, Board> _boards = new();

    public Task<Board> Get(string id)
    {
        if (!_boards.ContainsKey(id))
        {
            var boardId = Guid.NewGuid().ToString();
            var board = new Board(boardId, ClassicConfiguration.NewBoard());
            _boards[id] = board;
            return Task.FromResult(board);
        }

        return Task.FromResult(_boards[id]);
    }

    public Task Save(Board board)
    {
        _boards[board.Id] = board;
        return Task.CompletedTask;
    }
}