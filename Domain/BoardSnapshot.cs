using Domain.Configurations;
using Domain.GameStates;

namespace Domain;

public record BoardSnapshot(BoardSize BoardSize, GameStateSnapshot GameState, SquareSnapshot[,] Squares);