namespace Domain;

public record SquareSnapshot
{
    public string Name { get; }
    public Piece? Piece { get; }
    
    public static SquareSnapshot Occupied(string name, Piece piece) => new(name, piece);
    public static SquareSnapshot Unoccupied(string name) => new(name, null);

    private SquareSnapshot(string name, Piece? piece)
    {
        Name = name;
        Piece = piece;
    }
}