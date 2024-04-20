using Domain.Shared;

namespace Domain.Chessboard.PieceMoves.Classic;

public class ClassicWhiteManMoves : PieceMove
{
    // To be refactored later
    // Even more duplication added, but I'm not going to refactor it now
    // Not sure if all tests cases were discovered
    public IEnumerable<PossibleMove> PossibleMoves(Position currentPosition, BoardSnapshot boardSnapshot)
    {
        return GenerateMoves(currentPosition, [], boardSnapshot);
    }

    private List<PossibleMove> GenerateMoves(Position currentPosition, List<Position> excludedPositions, BoardSnapshot boardSnapshot)
    {
        if (currentPosition.Row == boardSnapshot.BoardSize.Rows - 1)
        {
            return new List<PossibleMove>();
        }

        var moves = new List<PossibleMove>();

        var rightBackward = currentPosition.RightBackward();
        if (rightBackward.IsWithinBoard(boardSnapshot.BoardSize) && !excludedPositions.Contains(rightBackward))
        {
            var piece = boardSnapshot.At(rightBackward);
            if (piece is not null && piece.Color == Color.Black)
            {
                var newPositionAfterCapture = rightBackward.RightBackward();
                if (newPositionAfterCapture.IsWithinBoard(boardSnapshot.BoardSize) && !excludedPositions.Contains(newPositionAfterCapture))
                {
                    if (boardSnapshot.At(newPositionAfterCapture) is null)
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
        }

        var leftBackward = currentPosition.LeftBackward();
        if (leftBackward.IsWithinBoard(boardSnapshot.BoardSize) && !excludedPositions.Contains(leftBackward))
        {
            var piece = boardSnapshot.At(leftBackward);
            if (piece is not null && piece.Color == Color.Black)
            {
                var newPositionAfterCapture = leftBackward.LeftBackward();
                if (newPositionAfterCapture.IsWithinBoard(boardSnapshot.BoardSize) && !excludedPositions.Contains(newPositionAfterCapture))
                {
                    if (boardSnapshot.At(newPositionAfterCapture) is null)
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
        }

        // To the left
        var leftForward = currentPosition.LeftForward();
        if (leftForward.IsWithinBoard(boardSnapshot.BoardSize) && !excludedPositions.Contains(leftForward))
        {
            var piece = boardSnapshot.At(leftForward);
            if (piece is not null && piece.Color == Color.Black)
            {
                var newPositionAfterCapture = leftForward.LeftForward();
                if (newPositionAfterCapture.IsWithinBoard(boardSnapshot.BoardSize) && !excludedPositions.Contains(newPositionAfterCapture))
                {
                    if (boardSnapshot.At(newPositionAfterCapture) is null)
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
            else if (piece is null && excludedPositions.Count == 0)
            {
                moves.Add(new PossibleMove(leftForward, new[] {leftForward}, 0));
            }
        }

        //To the right
        var rightForward = currentPosition.RightForward();
        if (rightForward.IsWithinBoard(boardSnapshot.BoardSize) && !excludedPositions.Contains(rightForward))
        {
            var piece = boardSnapshot.At(rightForward);
            if (piece is not null && piece.Color == Color.Black)
            {
                var newPositionAfterCapture = rightForward.RightForward();
                if (newPositionAfterCapture.IsWithinBoard(boardSnapshot.BoardSize) && !excludedPositions.Contains(newPositionAfterCapture))
                {
                    if (boardSnapshot.At(newPositionAfterCapture) is null)
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
            else if (piece is null && excludedPositions.Count == 0)
            {
                moves.Add(new PossibleMove(rightForward, new[] {rightForward}, 0));
            }
        }

        if (moves.Count > 0)
        {
            return moves.Where(x => x.CapturedPieces == moves.Max(x => x.CapturedPieces)).ToList();
        }

        return moves;
    }

    public bool UpgradeRequired(Position currentPosition)
    {
        return currentPosition.Row == Position.R8;
    }
}