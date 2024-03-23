using Domain.Pieces;

namespace Domain.PieceMoves.Classic;

public class ClassicBlackManMoves : PieceMove
{
    // To be refactored later
    // So far it's a copy & paste of white man moves
    // Once most of test cases are ready, refactoring will be needed
    public IEnumerable<Move> PossibleMoves(Position currentPosition, BoardSnapshot boardSnapshot)
    {
        var moves = new List<Move>();
        
        var rightForward = currentPosition.RightForward();
        if (rightForward.IsWithinBoard(boardSnapshot.BoardSize))
        {
            var newSquare = boardSnapshot.Squares[rightForward.Row, rightForward.Column];
            if (newSquare.Piece is not null && newSquare.Piece.Color == Color.White)
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
        }
        
        var leftForward = currentPosition.LeftForward();
        if (leftForward.IsWithinBoard(boardSnapshot.BoardSize))
        {
            var newSquare = boardSnapshot.Squares[leftForward.Row, leftForward.Column];
            if (newSquare.Piece is not null && newSquare.Piece.Color == Color.White)
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
        }
        
        // To the left
        var leftBackward = currentPosition.LeftBackward();
        if (leftBackward.IsWithinBoard(boardSnapshot.BoardSize))
        {
            var newSquare1 = boardSnapshot.Squares[leftBackward.Row, leftBackward.Column];
            if (newSquare1.Piece is not null && leftBackward.Column > 0 && newSquare1.Piece.Color == Color.White)
            {
                var newPositionAfterCapture = leftBackward.LeftBackward();
                var newSquareAfterCapture = boardSnapshot.Squares[newPositionAfterCapture.Row, newPositionAfterCapture.Column];
                if (newSquareAfterCapture.Piece is not null)
                {
                    //TODO: Square is already occupied
                }

                moves.Add(new Move(newPositionAfterCapture, new[] {leftBackward}, 1));
            }
            else if (newSquare1.Piece is null)
            {
                moves.Add(new Move(leftBackward, new[] {leftBackward}, 0));
            }
        }
        
        //To the right
        var rightBackward = currentPosition.RightBackward();
        if (rightBackward.IsWithinBoard(boardSnapshot.BoardSize))
        {
            var newSquare2 = boardSnapshot.Squares[rightBackward.Row, rightBackward.Column];
            if (newSquare2.Piece is not null && newSquare2.Piece.Color == Color.White)
            {
                var newPositionAfterCapture = rightBackward.RightBackward();
                var newSquareAfterCapture = boardSnapshot.Squares[newPositionAfterCapture.Row, newPositionAfterCapture.Column];
                if (newSquareAfterCapture.Piece is not null)
                {
                    //TODO: Square is already occupied
                }
                
                moves.Add(new Move(newPositionAfterCapture, new[] {rightBackward}, 1));
            }
            else if (newSquare2.Piece is null)
            {
                moves.Add(new Move(rightBackward, new[] {rightBackward}, 0));

            }
        }
        
        return moves.Count > 0 ? moves.Where(x => x.CapturedPieces == moves.Max(x => x.CapturedPieces)) : moves;
    }
}