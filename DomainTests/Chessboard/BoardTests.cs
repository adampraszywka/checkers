using Domain.Chessboard;
using Domain.Chessboard.Configurations.Classic;
using DomainTests.Chessboard.TestData;
using DomainTests.Extensions;
using static DomainTests.Extensions.TestSquare;

namespace DomainTests.Chessboard;

public class BoardTests
{
    private readonly AllParticipants _participants = ParticipantTestData.Participants;

    
    [Test]
    public void NewBoard()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new Board("ID", configuration, _participants.All);

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