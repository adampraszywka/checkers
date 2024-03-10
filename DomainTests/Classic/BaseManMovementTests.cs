using Domain;
using Domain.Configurations.Classic;
using Domain.Pieces;
using DomainTests.Classic.Data;
using DomainTests.Extensions;

namespace DomainTests.Classic;

public class BaseManMovementTests
{
    [Test]
    [TestCaseSource(typeof(WhiteManMoveForwardTestData))]
    public void WhiteManMoveForward(Position initialPosition, Position targetPosition)
    {
        var pieces = new List<(Piece, Position)> {(new Man("MyTestPiece", Color.White), initialPosition)};

        var configuration = ClassicConfiguration.FromSnapshot(pieces);
        var board = new Board(configuration);

        var result = board.Move("MyTestPiece", targetPosition);

        Assert.That(result.IsSuccess);
        Assert.That(board.Snapshot.ToTestSquares()[targetPosition.Row, targetPosition.Column], Is.EqualTo(TestSquare.WhiteMan));
    }
    
    // [Test]
    // [TestCaseSource(typeof(WhiteManForbiddenMovesTestData))]
    // public void WhiteForbiddenMove(Position initialPosition, Position targetPosition)
    // {
    //     var pieces = new List<(Piece, Position)> {(new Man("MyTestPiece", Color.White), initialPosition)};
    //
    //     var configuration = ClassicConfiguration.FromSnapshot(pieces);
    //     var board = new Board(configuration);
    //
    //     var result = board.Move("MyTestPiece", targetPosition);
    //
    //     Assert.That(result.IsSuccess);
    //     Assert.That(board.Snapshot.ToTestSquares()[targetPosition.Row, targetPosition.Column], Is.EqualTo(TestSquare.WhiteMan));
    // }
    
    // [Test]
    // [TestCaseSource(typeof(BlackManMoveForwardTestData))]
    // public void BlackManMoveForward(Position initialPosition, Position targetPosition)
    // {
    //     var pieces = new List<(Piece, Position)> {(new Man("MyTestPiece", Color.White), initialPosition)};
    //
    //     var configuration = ClassicConfiguration.FromSnapshot(pieces);
    //     var board = new Board(configuration);
    //
    //     var result = board.Move("MyTestPiece", targetPosition);
    //
    //     Assert.That(result.IsSuccess);
    //     Assert.That(board.Snapshot.ToTestSquares()[targetPosition.Row, targetPosition.Column], Is.EqualTo(TestSquare.WhiteMan));
    // }
}