using Domain;

namespace WebApi.Repository;

public interface GameRepository
{
    public Task<Game?> Get(string id);
    public Task Save(Game game);
}