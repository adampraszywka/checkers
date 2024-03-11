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

    public IEnumerable<Move> PossibleMoves(BoardSnapshot boardSnapshot)
    {
        if (Square is null)
        {
            throw InvalidBoardState.BrokenPieceSquareConnection;
        }

        var column = Square.Column;
        var row = Square.Row;

        if (row == boardSnapshot.Rows - 1)
        {
            return Enumerable.Empty<Move>();
        }
        
        if (column == Position.A)
        {
            return SingleMoveRight(row, column);
        }

        if (column == boardSnapshot.Columns - 1)
        {
            return SingleMoveLeft(row, column);
        }
        
        return TwoMovesLeftAndRight(row, column);

        static IEnumerable<Move> SingleMoveLeft(int row, int column)
        {
            var newPosition = new Position(row + 1, column - 1);
            var move = new Move(newPosition, new[] {newPosition}, 0);
            return new[] {move};
        }
        
        static IEnumerable<Move> SingleMoveRight(int row, int column)
        {
            var newPosition = new Position(row + 1, column + 1);
            var move = new Move(newPosition, new[] {newPosition}, 0);
            return new[] {move};
        }
        
        static IEnumerable<Move> TwoMovesLeftAndRight(int row, int column)
        {
            var newPosition1 = new Position(row + 1, column - 1);
            var newPosition2 = new Position(row + 1, column + 1);
            var move1 = new Move(newPosition1, new[] {newPosition1}, 0);
            var move2 = new Move(newPosition2, new[] {newPosition2}, 0);
            return new[] {move1, move2};
        }
    }
}