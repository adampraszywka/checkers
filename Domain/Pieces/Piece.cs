namespace Domain.Pieces;

public interface Piece : ObservablePiece
{
    public Square? Square { get; }
    public void Attach(Square square);
    public void Remove();

    public IEnumerable<Move> PossibleMoves(BoardSnapshot boardSnapshot);
}

public record Move(Position To, IEnumerable<Position> AffectedSquares, int CapturedPieces);