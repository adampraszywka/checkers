using Domain;

namespace DomainTests;

public class EmptyBoard8X8Tests
{
    private class EmptyBoardConfiguration : Configuration
    {
        public int BoardSize => 8;
        public int PlayerWhiteUpgradeRow => 7;
        public int PlayerBlackUpgradeRow => 0;
        public IEnumerable<(Piece, Position)> PiecesPositions => Enumerable.Empty<(Piece, Position)>();
    }
    
    [Test]
    public void EmptyBoard()
    {
        var board = new Board(new EmptyBoardConfiguration());

        var boardSnapshot = board.Snapshot;
        var boardSnapshotNames = boardSnapshot.Select(x => (x.Key, x.Value.Select(s => s.Name))).ToDictionary();
        var expected = new Dictionary<int, string[]>
        {
            {1, ["A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1"]},
            {2, ["A2", "B2", "C2", "D2", "E2", "F2", "G2", "H2"]},
            {3, ["A3", "B3", "C3", "D3", "E3", "F3", "G3", "H3"]},
            {4, ["A4", "B4", "C4", "D4", "E4", "F4", "G4", "H4"]},
            {5, ["A5", "B5", "C5", "D5", "E5", "F5", "G5", "H5"]},
            {6, ["A6", "B6", "C6", "D6", "E6", "F6", "G6", "H6"]},
            {7, ["A7", "B7", "C7", "D7", "E7", "F7", "G7", "H7"]},
            {8, ["A8", "B8", "C8", "D8", "E8", "F8", "G8", "H8"]},
        };

        Assert.That(boardSnapshotNames, Is.EquivalentTo(expected));
    }
}