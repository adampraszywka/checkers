using Domain.Chessboard.Configurations;
using Domain.Chessboard.GameStates;
using Domain.Chessboard.Pieces;

namespace Domain.Chessboard;

public record BoardSnapshot(BoardSize BoardSize, GameStateSnapshot GameState, SquareSnapshot[,] Squares)
{
    public Piece? At(Position position)
    {
        return position.IsWithinBoard(BoardSize) ? Squares[position.Row, position.Column].Piece : null;
    }
}