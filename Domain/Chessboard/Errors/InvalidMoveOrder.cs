using Domain.Chessboard.Pieces;
using FluentResults;

namespace Domain.Chessboard.Errors;

public class InvalidMoveOrder(Color currentPlayer) : Error($"It's a turn to move {currentPlayer.ToString()} piece")
{
    public Color CurrentPlayer = currentPlayer;
}