using Domain.Chessboard;
using Domain.Chessboard.Configurations.Classic;
using Domain.Chessboard.Errors;
using Domain.Chessboard.GameStates;
using Domain.Chessboard.PieceMoves;
using Domain.Chessboard.Pieces;
using DomainTests.Chessboard.TestData;
using DomainTests.Extensions;
using NSubstitute;

namespace DomainTests.Chessboard;

public class BoardPossibleMovesTests
{
    private readonly AllParticipants _participants = ParticipantTestData.Participants;
    
    [Test]
    [TestCase(-1, -1)]
    [TestCase(100, 100)]
    [TestCase(9, 9)]
    public void PossibleMovesOutOfBoard(int sourceRow, int sourceColumn)
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new Board("ID", configuration, _participants.All);
        var result = board.PossibleMoves(_participants.White, new Position(sourceRow, sourceColumn));

        Assert.That(result.HasError<PositionOutOfBoard>());
    }

    [Test]
    public void PossibleMovesSourceEmpty()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new Board("ID", configuration, _participants.All);

        var result = board.PossibleMoves(_participants.White, Position.B4);

        Assert.That(result.HasError<EmptySquare>());
    }

    [Test]
    public void PossibleMoves()
    {
        var possibleMoves = new[] {new PossibleMove(Position.B4, new[] {Position.B4}, 1)};

        var piece = Substitute.For<Piece>();
        var pieceMoves = Substitute.For<PieceMove>();
        pieceMoves.PossibleMoves(Position.A1, Arg.Any<BoardSnapshot>()).Returns(possibleMoves);
        var pieceMoveFactory = Substitute.For<PieceMoveFactory>();
        pieceMoveFactory.For(piece).Returns(pieceMoves);
        var pieceFactory = Substitute.For<PieceFactory>();

        var configuration = new TestConfiguration(pieceMoveFactory, pieceFactory, new[] {(piece, Position.A1)}, ClassicGameState.New);
        var board = new Board("ID", configuration, _participants.All);
        var result = board.PossibleMoves(_participants.White, Position.A1);

        Assert.That(result.IsSuccess);
        Assert.That(result.Value, Is.EqualTo(possibleMoves));
    }
}