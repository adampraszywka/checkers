using Domain.PieceMoves;
using Domain.Pieces;

namespace Domain.Configurations;

public interface Configuration
{
    public BoardSize BoardSize { get; }
    public IEnumerable<(Piece, Position)> PiecesPositions { get; }
    public PieceMoveFactory MoveFactory { get; }
    public PieceFactory PieceFactory { get; }
}