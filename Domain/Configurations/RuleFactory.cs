using Domain.Pieces;

namespace Domain.Configurations;

public interface RuleFactory
{
    public PieceRules RulesFor(Piece piece);
}