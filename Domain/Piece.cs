namespace Domain;

public interface Piece
{
    public string Id { get; }
    public Color Color { get; }
    public string Type { get; }
}

public enum Color
{
    Black, White    
}