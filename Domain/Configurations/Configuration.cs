﻿using Domain.Pieces;

namespace Domain.Configurations;

public interface Configuration
{
    public int BoardSize { get; }
    public IEnumerable<(Piece, Position)> PiecesPositions { get; }
}