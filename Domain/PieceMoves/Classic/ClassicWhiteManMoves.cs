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


        var rightBackward = currentPosition.RightBackward();
        if (rightBackward.IsWithinBoard(boardSnapshot.BoardSize))
        {
            var newSquare = boardSnapshot.Squares[rightBackward.Row, rightBackward.Column];
            if (newSquare.Piece is not null && newSquare.Piece.Color == Color.Black)
            {
                var newPositionAfterCapture = rightBackward.RightBackward();
                if (newPositionAfterCapture.IsWithinBoard(boardSnapshot.BoardSize))
                {
                    var newSquareAfterCapture = boardSnapshot.Squares[newPositionAfterCapture.Row, newPositionAfterCapture.Column];
                    if (newSquareAfterCapture.Piece is not null)
                    {
                        //TODO: Square is already occupied
                    }

                    moves.Add(new Move(newPositionAfterCapture, new[] {rightBackward}, 1));
                }
            }
        }
        
        var leftBackward = currentPosition.LeftBackward();
        if (leftBackward.IsWithinBoard(boardSnapshot.BoardSize))
        {
            var newSquare = boardSnapshot.Squares[leftBackward.Row, leftBackward.Column];
            if (newSquare.Piece is not null && newSquare.Piece.Color == Color.Black)
            {
                var newPositionAfterCapture = leftBackward.LeftBackward();
                if (newPositionAfterCapture.IsWithinBoard(boardSnapshot.BoardSize))
                {
                    var newSquareAfterCapture = boardSnapshot.Squares[newPositionAfterCapture.Row, newPositionAfterCapture.Column];
                    if (newSquareAfterCapture.Piece is not null)
                    {
                        //TODO: Square is already occupied
                    }

                    moves.Add(new Move(newPositionAfterCapture, new[] {leftBackward}, 1));
                }
            }
        }
        
        // To the left
        var leftForward = currentPosition.LeftForward();
        if (leftForward.IsWithinBoard(boardSnapshot.BoardSize))
        {
            var newSquare = boardSnapshot.Squares[leftForward.Row, leftForward.Column];
            if (newSquare.Piece is not null && newSquare.Piece.Color == Color.Black)
            {
                var newPositionAfterCapture = leftForward.LeftForward();
                if (newPositionAfterCapture.IsWithinBoard(boardSnapshot.BoardSize))
                {
                    var newSquareAfterCapture = boardSnapshot.Squares[newPositionAfterCapture.Row, newPositionAfterCapture.Column];
                    if (newSquareAfterCapture.Piece is not null)
                    {
                        //TODO: Square is already occupied
                    }

                    moves.Add(new Move(newPositionAfterCapture, new[] {leftForward}, 1));
                }
            }
            else if (newSquare.Piece is null)
            {
                moves.Add(new Move(leftForward, new[] {leftForward}, 0));
            }
        }
        
        //To the right
        var rightForward = currentPosition.RightForward();
        if (rightForward.IsWithinBoard(boardSnapshot.BoardSize))
        {
            var newSquare = boardSnapshot.Squares[rightForward.Row, rightForward.Column];
            if (newSquare.Piece is not null && newSquare.Piece.Color == Color.Black)
            {
                var newPositionAfterCapture = rightForward.RightForward();
                if (newPositionAfterCapture.IsWithinBoard(boardSnapshot.BoardSize))
                {
                    var newSquareAfterCapture = boardSnapshot.Squares[newPositionAfterCapture.Row, newPositionAfterCapture.Column];
                    if (newSquareAfterCapture.Piece is not null)
                    {
                        //TODO: Square is already occupied
                    }

                    moves.Add(new Move(newPositionAfterCapture, new[] {rightForward}, 1));
                }
            }
            else if (newSquare.Piece is null)
            {
                moves.Add(new Move(rightForward, new[] {rightForward}, 0));

            }
        }

        return moves.Count > 0 ? moves.Where(x => x.CapturedPieces == moves.Max(x => x.CapturedPieces)) : moves;
    }
}