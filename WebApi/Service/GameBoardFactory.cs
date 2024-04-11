using Domain.Repository;

namespace WebApi.Service;

public class GameBoardFactory(GameRepository gameRepository, BoardRepository boardRepository)
{
    public GameBoard Create(string gameId)
    {
        return new GameBoard(gameRepository, boardRepository, gameId);
    }
}