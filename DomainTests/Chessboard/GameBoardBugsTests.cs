using Domain.Chessboard;
using Domain.Chessboard.Configurations.Classic;
using Domain.Chessboard.Errors;
using Domain.Chessboard.GameStates;
using Domain.Chessboard.Pieces;
using Domain.Chessboard.Pieces.Classic;
using Domain.Shared;
using DomainTests.Chessboard.TestData;
using DomainTests.Extensions;
using static DomainTests.Extensions.TestSquare;

namespace DomainTests.Chessboard;

public class GameBoardBugsTests
{
    private readonly AllParticipants _participants = ParticipantTestData.Participants;
    
    [Test]
    public void InvalidSourcePositionMessageOnUnderperformingCapture()
    {
        var white = (Piece) new Man("W", Color.White);
        var black = (Piece) new Man("W", Color.Black);

        var configuration = ClassicConfiguration.FromSnapshot(new[]
        {
            (white, Position.A1), (white, Position.C1), (white, Position.E1), (white, Position.G1), 
            (white, Position.B2), (white, Position.D2), (white, Position.F2),  
            (white, Position.A3), (white, Position.C3),
            (white, Position.H4), (white, Position.D6), 
            
            (black, Position.B8), (black, Position.D8), (black, Position.F8), (black, Position.H8),
            (black, Position.A7), (black, Position.C7), (black, Position.E7), (black, Position.G7),
            (black, Position.B6), (black, Position.H6)
        }, [new Move(white, Position.F4, Position.D6)]);
        var board = new GameBoard("ID", configuration, _participants.All);

        var result = board.Move(_participants.Black, Position.H6, Position.G5);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.HasError<UnderperformingCaptureError>());
        Assert.That(result.Errors.Count, Is.EqualTo(1));
        var error = (UnderperformingCaptureError) result.Errors[0];
        
        Assert.That(error.SourceAvailable, Is.EquivalentTo(new [] {Position.C7, Position.E7}));

    }
}