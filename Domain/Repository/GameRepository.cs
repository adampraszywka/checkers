using Domain.Game;

namespace Domain.Repository;

public interface GameRepository
{
    public Task<GameInstance?> Get(string id);
    public Task Save(GameInstance gameInstance);
}