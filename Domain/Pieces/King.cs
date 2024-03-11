namespace Domain.Pieces;

public class King(string id, Color color) : Piece
{
    public string Id => id;
    public Color Color => color;
    public Type Type => Type.King; 
    public Square? Square { get; private set; }
    public void Attach(Square square)
    {
        Square = square;
    }

    public void Remove()
    {
        Square = null;
    }

    public IEnumerable<Move> PossibleMoves(BoardSnapshot snapshot)
    {
        throw new NotImplementedException();
    }
}