using Domain;

namespace DomainTests.Extensions;

public static class BoardSnapshotExtensions
{
    public static Dictionary<int, TestSquare[]> ToTestSquares(this BoardSnapshot snapshot)
    {
        return snapshot.Select(x => (x.Key, x.Value.Select(TestSquare.FromSquare).ToArray()))
            .OrderByDescending(x => x.Key)
            .ToDictionary();
    }
}