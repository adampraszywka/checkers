namespace Domain.Pieces.Classic;

public class King(string id, Color color) : Piece
{
    public string Id => id;
    public Color Color => color;
    public Type Type => Type.King; 
}