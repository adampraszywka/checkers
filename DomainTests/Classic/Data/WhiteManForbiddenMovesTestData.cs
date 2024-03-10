using System.Collections;
using Domain;

namespace DomainTests.Classic.Data;

public class WhiteManForbiddenMovesTestData : IEnumerable
{
    private readonly WhiteManMoveForwardTestData _allowedMoves = new();


    public IEnumerator GetEnumerator()
    {
        var enumerator = _allowedMoves.GetEnumerator();

        var values = new List<(Position Source, Position Target)>();
        while (enumerator.MoveNext())
        {
            var value = enumerator.Current as object[];
            var source = value[0] as Position;
            var target = value[1] as Position;
            values.Add((source, target));
        }

        var x= values.GroupBy(x => x.Source, (position, tuples) => new {Source = position, Targets = tuples.Select(x => x.Target)});

        
        
        throw new NotImplementedException();
    }
}