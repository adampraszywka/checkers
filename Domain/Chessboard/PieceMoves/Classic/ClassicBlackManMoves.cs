using Domain.Shared;

namespace Domain.Chessboard.PieceMoves.Classic;

public class ClassicBlackManMoves : PieceMove
{
    // To be refactored later
    // So far it's a copy & paste of white man moves
    // Once most of test cases are ready, refactoring will be needed
    public IEnumerable<PossibleMove> PossibleMoves(Position currentPosition, BoardSnapshot boardSnapshot)
    {
        return GenerateMoves(currentPosition, [], boardSnapshot);
    }
    
    private List<PossibleMove> GenerateMoves(Position currentPosition, List<Position> excludedPositions, BoardSnapshot boardSnapshot)
    {
        var moves = new List<PossibleMove>();

        var rightForward = currentPosition.RightForward();
        if (rightForward.IsWithinBoard(boardSnapshot.BoardSize) && !excludedPositions.Contains(rightForward))
        {
            var newSquare = boardSnapshot.Squares[rightForward.Row, rightForward.Column];
            if (newSquare.Piece is not null && newSquare.Piece.Color == Color.White)
            {
                var newPositionAfterCapture = rightForward.RightForward();
                if (newPositionAfterCapture.IsWithinBoard(boardSnapshot.BoardSize) && !excludedPositions.Contains(newPositionAfterCapture))
                {
                    var newSquareAfterCapture = boardSnapshot.Squares[newPositionAfterCapture.Row, newPositionAfterCapture.Column];
                    if (newSquareAfterCapture.Piece is null)
                    {
                        excludedPositions.Add(rightForward);
                        excludedPositions.Add(newPositionAfterCapture);
                        
                        var move = new PossibleMove(newPositionAfterCapture, new[] {rightForward}, 1);
                        var nextMoves = GenerateMoves(newPositionAfterCapture, excludedPositions, boardSnapshot);
                        
                        if (nextMoves.Count == 0)
                        {
                            moves.Add(move);
                        }
                        else
                        {
                            var x = nextMoves.Select(x => new PossibleMove(x.To, move.AffectedSquares.Union(x.AffectedSquares), x.CapturedPieces + 1));
                            moves.AddRange(x);
                        }                       
                    }
                }
            }
        }

        var leftForward = currentPosition.LeftForward();
        if (leftForward.IsWithinBoard(boardSnapshot.BoardSize) && !excludedPositions.Contains(leftForward))
        {
            var newSquare = boardSnapshot.Squares[leftForward.Row, leftForward.Column];
            if (newSquare.Piece is not null && newSquare.Piece.Color == Color.White)
            {
                var newPositionAfterCapture = leftForward.LeftForward();
                if (newPositionAfterCapture.IsWithinBoard(boardSnapshot.BoardSize) && !excludedPositions.Contains(newPositionAfterCapture))
                {
                    var newSquareAfterCapture = boardSnapshot.Squares[newPositionAfterCapture.Row, newPositionAfterCapture.Column];
                    if (newSquareAfterCapture.Piece is null)
                    {
                        excludedPositions.Add(leftForward);
                        excludedPositions.Add(newPositionAfterCapture);
                        
                        var move = new PossibleMove(newPositionAfterCapture, new[] {leftForward}, 1);
                        var nextMoves = GenerateMoves(newPositionAfterCapture, excludedPositions, boardSnapshot);
                        
                        if (nextMoves.Count == 0)
                        {
                            moves.Add(move);
                        }
                        else
                        {
                            var x = nextMoves.Select(x => new PossibleMove(x.To, move.AffectedSquares.Union(x.AffectedSquares), x.CapturedPieces + 1));
                            moves.AddRange(x);
                        }                       
                    }
                }
            }
        }

        // To the left
        var leftBackward = currentPosition.LeftBackward();
        if (leftBackward.IsWithinBoard(boardSnapshot.BoardSize) & !excludedPositions.Contains(leftBackward))
        {
            var newSquare1 = boardSnapshot.Squares[leftBackward.Row, leftBackward.Column];
            if (newSquare1.Piece is not null && newSquare1.Piece.Color == Color.White)
            {
                var newPositionAfterCapture = leftBackward.LeftBackward();
                if (newPositionAfterCapture.IsWithinBoard(boardSnapshot.BoardSize) && !excludedPositions.Contains(newPositionAfterCapture))
                {
                    var newSquareAfterCapture = boardSnapshot.Squares[newPositionAfterCapture.Row, newPositionAfterCapture.Column];
                    if (newSquareAfterCapture.Piece is null)
                    {
                        excludedPositions.Add(leftBackward);
                        excludedPositions.Add(newPositionAfterCapture);
                        
                        var move = new PossibleMove(newPositionAfterCapture, new[] {leftBackward}, 1);
                        var nextMoves = GenerateMoves(newPositionAfterCapture, excludedPositions, boardSnapshot);
                        
                        if (nextMoves.Count == 0)
                        {
                            moves.Add(move);
                        }
                        else
                        {
                            var x = nextMoves.Select(x => new PossibleMove(x.To, move.AffectedSquares.Union(x.AffectedSquares), x.CapturedPieces + 1));
                            moves.AddRange(x);
                        }
                    }
                }
            }
            else if (newSquare1.Piece is null && excludedPositions.Count == 0)
            {
                moves.Add(new PossibleMove(leftBackward, new[] {leftBackward}, 0));
            }
        }

        //To the right
        var rightBackward = currentPosition.RightBackward();
        if (rightBackward.IsWithinBoard(boardSnapshot.BoardSize) && !excludedPositions.Contains(rightBackward))
        {
            var newSquare2 = boardSnapshot.Squares[rightBackward.Row, rightBackward.Column];
            if (newSquare2.Piece is not null && newSquare2.Piece.Color == Color.White)
            {
                var newPositionAfterCapture = rightBackward.RightBackward();
                if (newPositionAfterCapture.IsWithinBoard(boardSnapshot.BoardSize) && !excludedPositions.Contains(newPositionAfterCapture))
                {
                    var newSquareAfterCapture = boardSnapshot.Squares[newPositionAfterCapture.Row, newPositionAfterCapture.Column];
                    if (newSquareAfterCapture.Piece is null)
                    {
                        excludedPositions.Add(rightBackward);
                        excludedPositions.Add(newPositionAfterCapture);
                        
                        var move = new PossibleMove(newPositionAfterCapture, new[] {rightBackward}, 1);
                        var nextMoves = GenerateMoves(newPositionAfterCapture, excludedPositions, boardSnapshot);
                        
                        if (nextMoves.Count == 0)
                        {
                            moves.Add(move);
                        }
                        else
                        {
                            var x = nextMoves.Select(x => new PossibleMove(x.To, move.AffectedSquares.Union(x.AffectedSquares), x.CapturedPieces + 1));
                            moves.AddRange(x);
                        }
                    }
                }
            }
            else if (newSquare2.Piece is null && excludedPositions.Count == 0)
            {
                moves.Add(new PossibleMove(rightBackward, new[] {rightBackward}, 0));
            }
        }

        return moves.Count > 0 ? moves.Where(x => x.CapturedPieces == moves.Max(x => x.CapturedPieces)).ToList() : moves;
    }

    public bool UpgradeRequired(Position currentPosition)
    {
        return currentPosition.Row == Position.R1;
    }
}