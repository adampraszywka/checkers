using Domain.Exceptions;

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

    public IEnumerable<Move> PossibleMoves()
    {
        if (Square is null)
        {
            throw InvalidBoardState.BrokenPieceSquareConnection;
        }

        var column = Square.Column;
        var row = Square.Row;

        var newPosition = new Position(row + 1, column + 1);

        var move = new Move(newPosition, new[] {newPosition}, 0);

        return new[] {move};
    }
}