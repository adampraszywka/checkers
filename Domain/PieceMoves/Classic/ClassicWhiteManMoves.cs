namespace Domain.PieceMoves.Classic;

public class ClassicWhiteManMoves : PieceMove
{
    public IEnumerable<Move> PossibleMoves(Position currentPosition, BoardSnapshot boardSnapshot)
    {
        var column = currentPosition.Column;
        var row = currentPosition.Row;

        if (row == boardSnapshot.Rows - 1)
        {
            return Enumerable.Empty<Move>();
        }
        
        if (column == Position.A)
        {
            var newPosition = new Position(row + 1, column + 1);
            var newSquare = boardSnapshot.Squares[newPosition.Row, newPosition.Column];

            if (newSquare.Piece is not null)
            {
                return Enumerable.Empty<Move>();
            }

            var move = new Move(newPosition, new[] {newPosition}, 0);
            return new[] {move};
        }

        if (column == boardSnapshot.Columns - 1)
        {
            var newPosition = new Position(row + 1, column - 1);
            var newSquare = boardSnapshot.Squares[newPosition.Row, newPosition.Column];

            if (newSquare.Piece is not null)
            {
                return Enumerable.Empty<Move>();
            }
            
            var move = new Move(newPosition, new[] {newPosition}, 0);
            return new[] {move};
        }

        var moves = new List<Move>();
        
        var newPosition1 = new Position(row + 1, column - 1);
        var newPosition2 = new Position(row + 1, column + 1);

        var newSquare1 = boardSnapshot.Squares[newPosition1.Row, newPosition1.Column];
        var newSquare2 = boardSnapshot.Squares[newPosition2.Row, newPosition2.Column];

        if (newSquare1.Piece is null)
        {
            moves.Add(new Move(newPosition1, new[] {newPosition1}, 0));
        }

        if (newSquare2.Piece is null)
        {
            moves.Add(new Move(newPosition2, new[] {newPosition2}, 0));

        }

        return moves;
    }
}