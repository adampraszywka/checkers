﻿using Domain;
using Domain.PieceMoves;

namespace DomainTests.PieceMoves.Classic.TestData.Dto;

public record PieceBackwardCaptureBlockTestCase
{
    public required Position SourcePiece { get; init; }
    public required IEnumerable<Position> CapturedPieces { get; init; }
    public required IEnumerable<Position> BlockingPieces { get; init; }
    public required IEnumerable<Move> Moves { get; init; }
}