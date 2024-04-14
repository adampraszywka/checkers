using Domain.Chessboard;
using Domain.Chessboard.Configurations.Classic;
using Domain.Chessboard.Pieces;
using DomainTests.Chessboard.TestData;
using DomainTests.Extensions;
using Extension;
using static DomainTests.Extensions.TestSquare;

namespace DomainTests.Chessboard;

public class GameBoardTests
{
    private readonly AllParticipants _participants = ParticipantTestData.Participants;

    [Test]
    public void EmptyBoard()
    {
        var configuration = ClassicConfiguration.FromSnapshot(Enumerable.Empty<(Piece, Position)>());
        var board = new GameBoard("ID", configuration, _participants.All);

        var boardSnapshot = board.Snapshot;
        var boardSnapshotNames = boardSnapshot.Squares.Transform(s => s.Id);


        var expected = new[,]
        {
            {"A8", "B8", "C8", "D8", "E8", "F8", "G8", "H8"},
            {"A7", "B7", "C7", "D7", "E7", "F7", "G7", "H7"},
            {"A6", "B6", "C6", "D6", "E6", "F6", "G6", "H6"},
            {"A5", "B5", "C5", "D5", "E5", "F5", "G5", "H5"},
            {"A4", "B4", "C4", "D4", "E4", "F4", "G4", "H4"},
            {"A3", "B3", "C3", "D3", "E3", "F3", "G3", "H3"},
            {"A2", "B2", "C2", "D2", "E2", "F2", "G2", "H2"},
            {"A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1"}
        };

        BoardAssert.ReversedRowsEqualTo(expected, boardSnapshotNames);
    }
    
    [Test]
    public void NewBoard()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new GameBoard("ID", configuration, _participants.All);

        var snapshot = board.Snapshot.ToTestSquares();
        var expected = new[,]
        {
            {Empty, BlackMan, Empty, BlackMan, Empty, BlackMan, Empty, BlackMan},
            {BlackMan, Empty, BlackMan, Empty, BlackMan, Empty, BlackMan, Empty},
            {Empty, BlackMan, Empty, BlackMan, Empty, BlackMan, Empty, BlackMan},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {WhiteMan, Empty, WhiteMan, Empty, WhiteMan, Empty, WhiteMan, Empty},
            {Empty, WhiteMan, Empty, WhiteMan, Empty, WhiteMan, Empty, WhiteMan},
            {WhiteMan, Empty, WhiteMan, Empty, WhiteMan, Empty, WhiteMan, Empty}
        };

        BoardAssert.ReversedRowsEqualTo(expected, snapshot);
    }
}