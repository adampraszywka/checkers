using Domain.Configurations;

namespace Domain;

public record BoardSnapshot(BoardSize BoardSize, SquareSnapshot[,] Squares);