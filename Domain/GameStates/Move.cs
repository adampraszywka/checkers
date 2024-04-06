using Domain.Pieces;

namespace Domain.GameStates;

public record Move(Piece Piece, Position From, Position To);