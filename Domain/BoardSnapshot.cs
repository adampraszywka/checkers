using Domain.Configurations;
using Domain.GameStates;
using Domain.Pieces;

namespace Domain;

public record BoardSnapshot(BoardSize BoardSize, GameStateSnapshot GameState, SquareSnapshot[,] Squares)
{
    public Piece? At(Position position) => position.IsWithinBoard(BoardSize) ? Squares[position.Row, position.Column].Piece : null;
}