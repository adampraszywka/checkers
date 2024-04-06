using Domain;

namespace WebApi.Repository;

public interface BoardRepository
{
    public Task<Board> Get(string id);
    public Task Save(Board board);
}