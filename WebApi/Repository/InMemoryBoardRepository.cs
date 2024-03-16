using Domain;
using Domain.Configurations.Classic;

namespace WebApi.Repository;

public class InMemoryBoardRepository : BoardRepository
{
    private readonly Board _board;
    
    public InMemoryBoardRepository()
    {
        var config = ClassicConfiguration.NewBoard();
        _board = new Board(config);
    }
    
    public Task<Board> Get()
    {
        return Task.FromResult(_board);
    }
}