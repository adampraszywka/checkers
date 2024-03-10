namespace Domain.Pieces;

public class Man(string id, Color color) : Piece
{
    public string Id => id;
    public Color Color => color;
    public Type Type => Type.Man;
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