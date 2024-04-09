using Domain;

namespace WebApi.Repository;

public class InMemoryGameRepository : GameRepository
{
    private readonly Dictionary<string, Game> _games = new();
    
    public Task<Game?> Get(string id)
    {
        if (!_games.ContainsKey(id))
        {
            return Task.FromResult<Game?>(null);
        }

        return Task.FromResult<Game?>(_games[id]);
    }

    public Task Save(Game game)
    {
        _games[game.Id] = game;
        return Task.CompletedTask;
    }
}