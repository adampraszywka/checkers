namespace Domain.PieceMoves.Classic;

public class ClassicBlackManMoves : PieceMove
{
    public IEnumerable<Move> PossibleMoves(Position currentPosition, BoardSnapshot boardSnapshot)
    {
        var column = currentPosition.Column;
        var row = currentPosition.Row;

        if (row == Position.R1)
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
            var newPosition = new Position(row - 1, column - 1);
            var move = new Move(newPosition, new[] {newPosition}, 0);
            return new[] {move};
        }

        static IEnumerable<Move> SingleMoveRight(int row, int column)
        {
            var newPosition = new Position(row - 1, column + 1);
            var move = new Move(newPosition, new[] {newPosition}, 0);
            return new[] {move};
        }

        static IEnumerable<Move> TwoMovesLeftAndRight(int row, int column)
        {
            var newPosition1 = new Position(row - 1, column - 1);
            var newPosition2 = new Position(row - 1, column + 1);
            var move1 = new Move(newPosition1, new[] {newPosition1}, 0);
            var move2 = new Move(newPosition2, new[] {newPosition2}, 0);
            return new[] {move1, move2};
        }
    }
}