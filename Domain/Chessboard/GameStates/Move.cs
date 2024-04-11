using Domain.Chessboard.Pieces;

namespace Domain.Chessboard.GameStates;

public record Move(Piece Piece, Position From, Position To);