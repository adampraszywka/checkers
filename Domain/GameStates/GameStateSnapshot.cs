using Domain.Pieces;

namespace Domain.GameStates;

public record GameStateSnapshot(IEnumerable<Move> Log, Color CurrentPlayer);