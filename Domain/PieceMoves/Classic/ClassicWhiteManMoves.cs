using Domain.Pieces;

namespace Domain.PieceMoves.Classic;

public class ClassicWhiteManMoves : PieceMove
{
    // To be refactored later
    public IEnumerable<Move> PossibleMoves(Position currentPosition, BoardSnapshot boardSnapshot)
    {
        if (currentPosition.Row == boardSnapshot.BoardSize.Rows - 1)
        {
            return Enumerable.Empty<Move>();
        }
        
        var moves = new List<Move>();
        
        // To the left
        var newPosition1 = currentPosition.LeftForward();
        if (newPosition1.IsWithinBoard(boardSnapshot.BoardSize))
        {
            var newSquare1 = boardSnapshot.Squares[newPosition1.Row, newPosition1.Column];
            if (newSquare1.Piece is not null && newSquare1.Piece.Color == Color.Black)
            {
                var newPositionAfterCapture = newPosition1.LeftForward();
                if (newPositionAfterCapture.IsWithinBoard(boardSnapshot.BoardSize))
                {
                    var newSquareAfterCapture = boardSnapshot.Squares[newPositionAfterCapture.Row, newPositionAfterCapture.Column];
                    if (newSquareAfterCapture.Piece is not null)
                    {
                        //TODO: Square is already occupied
                    }

                    moves.Add(new Move(newPositionAfterCapture, new[] {newPosition1}, 1));
                }
            }
            else if (newSquare1.Piece is null)
            {
                moves.Add(new Move(newPosition1, new[] {newPosition1}, 0));
            }
        }
        
        //To the right
        var newPosition2 = currentPosition.RightForward();
        if (newPosition2.IsWithinBoard(boardSnapshot.BoardSize))
        {
            var newSquare2 = boardSnapshot.Squares[newPosition2.Row, newPosition2.Column];
            if (newSquare2.Piece is not null && newSquare2.Piece.Color == Color.Black)
            {
                var newPositionAfterCapture = newPosition2.RightForward();
                if (newPositionAfterCapture.IsWithinBoard(boardSnapshot.BoardSize))
                {
                    var newSquareAfterCapture = boardSnapshot.Squares[newPositionAfterCapture.Row, newPositionAfterCapture.Column];
                    if (newSquareAfterCapture.Piece is not null)
                    {
                        //TODO: Square is already occupied
                    }

                    moves.Add(new Move(newPositionAfterCapture, new[] {newPosition2}, 1));
                }
            }
            else if (newSquare2.Piece is null)
            {
                moves.Add(new Move(newPosition2, new[] {newPosition2}, 0));

            }
        }

        return moves.Count > 0 ? moves.Where(x => x.CapturedPieces == moves.Max(x => x.CapturedPieces)) : moves;
    }
}