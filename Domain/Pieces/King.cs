namespace Domain.Pieces;

public class King(string id, Color color) : Piece
{
    public string Id => id;
    public Color Color => color;
    public string Type => "king";
    public Square? Square { get; private set; }
    public void Attach(Square square)
    {
        Square = square;
    }

    public void Remove()
    {
        Square = null;
    }
}