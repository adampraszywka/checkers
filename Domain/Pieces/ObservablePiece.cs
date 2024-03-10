namespace Domain.Pieces;

public interface ObservablePiece
{
    public string Id { get; }
    public Color Color { get; }
    public Type Type { get; }
}

public enum Type
{
    Man, King
}
