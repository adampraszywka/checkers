using Domain.Pieces;

namespace Domain.Log;

public record Move(Piece Piece, Position From, Position To);