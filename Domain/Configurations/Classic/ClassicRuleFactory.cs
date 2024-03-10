using Domain.Pieces;
using Type = Domain.Pieces.Type;

namespace Domain.Configurations.Classic;

public class ClassicRuleFactory : RuleFactory
{
    private readonly ClassicManRules _classicManRules = new();
    private readonly ClassicKingRules _classicKingRules = new();
    
    public PieceRules RulesFor(Piece piece)
    {
        if (piece.Type is Type.King)
        {
            return _classicKingRules;
        }

        if (piece.Type is Type.Man)
        {
            return _classicManRules;
        }

        throw new ArgumentException();
    }
}