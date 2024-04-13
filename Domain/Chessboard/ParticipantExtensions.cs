using Domain.Chessboard.Pieces;
using Domain.Shared;

namespace Domain.Chessboard;

public static class ParticipantExtensions
{
    public static bool CanMove(this Participant participant, Piece piece) => participant.Color == piece.Color;
}