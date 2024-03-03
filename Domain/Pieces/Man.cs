namespace Domain.Pieces;

public class Man(string id, Color color) : Piece
{
    public string Id => id;
    public Color Color => color;
    public string Type => "man";
}