namespace Domain;

public record SquareSnapshot
{
    public string Id { get; }
    public Piece? Piece { get; }
    
    public static SquareSnapshot Occupied(string name, Piece piece) => new(name, piece);
    public static SquareSnapshot Unoccupied(string name) => new(name, null);

    private SquareSnapshot(string id, Piece? piece)
    {
        Id = id;
        Piece = piece;
    }
}