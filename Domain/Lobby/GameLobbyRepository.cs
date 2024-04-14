namespace Domain.Lobby;

public interface GameLobbyRepository
{
    public Task<GameLobby?> Get(string id);
    public Task Save(GameLobby gameLobby);
}