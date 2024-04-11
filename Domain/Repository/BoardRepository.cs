using Domain.Chessboard;

namespace Domain.Repository;

public interface BoardRepository
{
    public Task<Board> Get(string id);
    public Task Save(Board board);
}