using Domain.Pieces;
using FluentResults;

namespace Domain.Errors.Board;

public class InvalidMoveOrder(Color currentPlayer) : Error($"It's a turn to move {currentPlayer.ToString()} piece")
{
    public Color CurrentPlayer = currentPlayer;
}