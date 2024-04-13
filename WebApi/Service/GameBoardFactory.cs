using Domain.Chessboard;

namespace WebApi.Service;

public class GameBoardFactory(BoardRepository boardRepository)
{
    public GameBoard Create(string gameId)
    {
        return new GameBoard(boardRepository, gameId);
    }
}