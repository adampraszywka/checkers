using Domain.Game;
using Domain.Repository;

namespace WebApi.Repository;

public class InMemoryGameRepository : GameRepository
{
    private readonly Dictionary<string, GameInstance> _games = new();

    public Task<GameInstance?> Get(string id)
    {
        if (!_games.ContainsKey(id)) return Task.FromResult<GameInstance?>(null);

        return Task.FromResult<GameInstance?>(_games[id]);
    }

    public Task Save(GameInstance gameInstance)
    {
        _games[gameInstance.Id] = gameInstance;
        return Task.CompletedTask;
    }
}