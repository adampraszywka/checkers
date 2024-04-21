using Domain.Chessboard.Pieces;
using Domain.Shared;
using Type = Domain.Chessboard.Pieces.Type;

namespace Domain.Chessboard.PieceMoves.Classic;

public class ClassicPieceMoveFactory : PieceMoveFactory
{   
    private readonly ClassicWhiteManMoves _whiteManMoves = new();
    private readonly ClassicBlackManMoves _blackManMoves = new();
    private readonly ClassicWhiteKingMoves _whiteKingMoves = new();
    private readonly ClassicBlackKingMoves _blackKingMoves = new();
    
    
    public PieceMove For(Piece piece)
    {
        return (piece.Type, piece.Color) switch
        {
            (Type.Man, Color.White) => _whiteManMoves,
            (Type.Man, Color.Black) => _blackManMoves,
            (Type.King, Color.White) => _whiteKingMoves,
            (Type.King, Color.Black) => _blackKingMoves,
            _ => throw new InvalidOperationException()
        };
    }
}