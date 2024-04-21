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

public class GameBoardMoveTests
{
    private readonly AllParticipants _participants = ParticipantTestData.Participants;
    

    [Test]
    [TestCase(4, 0, -100, -100)]
    [TestCase(4, 0, -1, -1)]
    [TestCase(4, 0, 0, 8)]
    [TestCase(4, 0, 0, 9)]
    [TestCase(4, 0, 8, 0)]
    [TestCase(4, 0, 9, 0)]
    [TestCase(4, 0, 100, 100)]
    [TestCase(-1, -1, 0, 0)]
    [TestCase(100, 100, 0, 0)]
    [TestCase(9, 9, 0, 0)]
    [TestCase(8, 7, 0, 0)]
    [TestCase(7, 8, 0, 0)]
    public void MoveOutOfBoard(int sourceRow, int sourceColumn, int targetRow, int targetColumn)
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new GameBoard("ID", configuration, _participants.All);

        var result = board.Move(_participants.White, new Position(sourceRow, sourceColumn), new Position(targetRow, targetColumn));

        Assert.That(result.HasError<PositionOutOfBoard>());
    }

    [Test]
    public void SquareEmpty()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new GameBoard("ID", configuration, _participants.All);

        var result = board.Move(_participants.White, Position.B4, Position.C5);

        Assert.That(result.HasError<EmptySquare>());
    }

    [Test]
    public void MoveNotAllowed()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new GameBoard("ID", configuration, _participants.All);

        var result = board.Move(_participants.White, Position.A1, Position.H8);

        Assert.That(result.HasError<MoveNotAllowed>());
    }

    [Test]
    public void MoveNotAllowedDueToOtherPieceWithHigherCaptureCount()
    {
        var white = (Piece) new Man("W", Color.White);
        var black = (Piece) new Man("W", Color.Black);

        var configuration = ClassicConfiguration.FromSnapshot(new[]
        {
            (white, Position.A1), (black, Position.B2),
            (white, Position.G1), (black, Position.F2), (black, Position.F4)
            
        });
        var board = new GameBoard("ID", configuration, _participants.All);

        var result = board.Move(_participants.White, Position.A1, Position.C3);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.HasError<UnderperformingCaptureError>());

        var snapshot = board.Snapshot.ToTestSquares();
        var expected = new[,]
        {
            {Empty,     Empty,      Empty,  Empty,      Empty,  Empty,      Empty,      Empty},
            {Empty,     Empty,      Empty,  Empty,      Empty,  Empty,      Empty,      Empty},
            {Empty,     Empty,      Empty,  Empty,      Empty,  Empty,      Empty,      Empty},
            {Empty,     Empty,      Empty,  Empty,      Empty,  Empty,      Empty,      Empty},
            {Empty,     Empty,      Empty,  Empty,      Empty,  BlackMan,   Empty,      Empty},
            {Empty,     Empty,      Empty,  Empty,      Empty,  Empty,      Empty,      Empty},
            {Empty,     BlackMan,   Empty,  Empty,      Empty,  BlackMan,   Empty,      Empty},
            {WhiteMan,  Empty,      Empty,  Empty,      Empty,  Empty,      WhiteMan,   Empty}
        };

        BoardAssert.ReversedRowsEqualTo(expected, snapshot);
    }

    [Test]
    public void BlackPieceMoveNotAllowedDueToGameState()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new GameBoard("ID", configuration, _participants.All);

        var result = board.Move(_participants.Black, Position.C7, Position.B6);

        Assert.That(result.HasError<InvalidMoveOrder>());
    }

    [Test]
    public void WhitePieceMoveNotAllowedDueToGameState()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new GameBoard("ID", configuration, _participants.All);

        var whiteMove1 = board.Move(_participants.White, Position.A3, Position.B4);
        Assert.That(whiteMove1.IsSuccess);

        var result = board.Move(_participants.White, Position.C3, Position.D4);

        Assert.That(result.HasError<InvalidMoveOrder>());
    }
    
    [Test]
    public void NotParticipatingPlayerCannotMoveBlackPiece()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new GameBoard("ID", configuration, _participants.All);

        Assert.That(board.Move(_participants.White, Position.A3, Position.B4).IsSuccess, Is.True);
        
        var result = board.Move(_participants.NotParticipating, Position.C3, Position.D4);
        Assert.That(result.HasError<PlayerDoesNotParticipate>());
    }
    
    [Test]
    public void NotParticipatingPlayerCannotMoveWhitePiece()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new GameBoard("ID", configuration, _participants.All);

        var result = board.Move(_participants.NotParticipating, Position.B6, Position.A5);
        
        Assert.That(result.HasError<PlayerDoesNotParticipate>());
    }
    
    [Test]
    public void WhitePlayerCannotMoveBlackPiece()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new GameBoard("ID", configuration, _participants.All);

        var result = board.Move(_participants.White, Position.B6, Position.A5);
        
        Assert.That(result.HasError<PieceBelongsToTheOtherPlayer>());
    }

    [Test]
    public void BlackPlayerCannotMoveWhitePiece()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new GameBoard("ID", configuration, _participants.All);

        Assert.That(board.Move(_participants.White, Position.A3, Position.B4).IsSuccess, Is.True);
        
        var result = board.Move(_participants.Black, Position.C3, Position.D4);
        Assert.That(result.HasError<PieceBelongsToTheOtherPlayer>());
    }

    [Test]
    public void FirstMove()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new GameBoard("ID", configuration, _participants.All);

        var result = board.Move(_participants.White, Position.A3, Position.B4);

        Assert.That(result.IsSuccess);

        var snapshot = board.Snapshot.ToTestSquares();
        var expected = new[,]
        {
            {Empty, BlackMan, Empty, BlackMan, Empty, BlackMan, Empty, BlackMan},
            {BlackMan, Empty, BlackMan, Empty, BlackMan, Empty, BlackMan, Empty},
            {Empty, BlackMan, Empty, BlackMan, Empty, BlackMan, Empty, BlackMan},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, WhiteMan, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, WhiteMan, Empty, WhiteMan, Empty, WhiteMan, Empty},
            {Empty, WhiteMan, Empty, WhiteMan, Empty, WhiteMan, Empty, WhiteMan},
            {WhiteMan, Empty, WhiteMan, Empty, WhiteMan, Empty, WhiteMan, Empty}
        };

        BoardAssert.ReversedRowsEqualTo(expected, snapshot);
    }

    [Test]
    public void WhiteUpgradesToKingOnceOppositeSideOfBoardReachedByMove()
    {
        var white = new Man("W", Color.White);

        var configuration = ClassicConfiguration.FromSnapshot(new[] {((Piece) white, Position.E7)});
        var board = new GameBoard("ID", configuration, _participants.All);

        var result = board.Move(_participants.White, Position.E7, Position.D8);

        Assert.That(result.IsSuccess);

        var snapshot = board.Snapshot.ToTestSquares();
        var expected = new[,]
        {
            {Empty, Empty, Empty, WhiteKing, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty}
        };

        BoardAssert.ReversedRowsEqualTo(expected, snapshot);
    }

    [Test]
    public void WhiteUpgradesToKingOnceOppositeSideOfBoardReachedByCapture()
    {
        var white = new Man("A1", Color.White);
        var black = new Man("A2", Color.Black);

        var configuration = ClassicConfiguration.FromSnapshot(new[] {((Piece) black, Position.E7), ((Piece) white, Position.F6)});
        var board = new GameBoard("ID", configuration, _participants.All);

        var result = board.Move(_participants.White, Position.F6, Position.D8);

        Assert.That(result.IsSuccess);

        var snapshot = board.Snapshot.ToTestSquares();
        var expected = new[,]
        {
            {Empty, Empty, Empty, WhiteKing, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty}
        };

        BoardAssert.ReversedRowsEqualTo(expected, snapshot);
    }

    [Test]
    public void BlackUpgradesToKingOnceOppositeSideOfBoardReachedByMove()
    {
        var white = new Man("W", Color.White);
        var black = new Man("B", Color.Black);

        var configuration =
            ClassicConfiguration.FromSnapshot(new[] {((Piece) black, Position.D2), (white, Position.G1)});
        var board = new GameBoard("ID", configuration, _participants.All);

        Assert.That(board.Move(_participants.White, Position.G1, Position.H2).IsSuccess);

        var result = board.Move(_participants.Black, Position.D2, Position.C1);

        Assert.That(result.IsSuccess);

        var snapshot = board.Snapshot.ToTestSquares();
        var expected = new[,]
        {
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, WhiteMan},
            {Empty, Empty, BlackKing, Empty, Empty, Empty, Empty, Empty}
        };

        BoardAssert.ReversedRowsEqualTo(expected, snapshot);
    }

    [Test]
    public void BlackUpgradesToKingOnceOppositeSideOfBoardReachedByCapture()
    {
        var white = new Man("A1", Color.White);
        var black = new Man("A2", Color.Black);

        var configuration =
            ClassicConfiguration.FromSnapshot(new[] {((Piece) black, Position.C3), ((Piece) white, Position.C1)});
        var board = new GameBoard("ID", configuration, _participants.All);

        Assert.That(board.Move(_participants.White, Position.C1, Position.D2).IsSuccess);

        var result = board.Move(_participants.Black, Position.C3, Position.E1);

        Assert.That(result.IsSuccess);

        var snapshot = board.Snapshot.ToTestSquares();
        var expected = new[,]
        {
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty},
            {Empty, Empty, Empty, Empty, BlackKing, Empty, Empty, Empty}
        };

        BoardAssert.ReversedRowsEqualTo(expected, snapshot);
    }

    [Test]
    public void GameStateForNewBoard()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new GameBoard("ID", configuration, _participants.All);

        Assert.That(board.GameState.Log, Is.Empty);
        Assert.That(board.GameState.CurrentPlayer, Is.EqualTo(Color.White));
    }

    [Test]
    public void GameStateAfterWhitePieceMove()
    {
        var white = new Man("A1", Color.White);

        var configuration = ClassicConfiguration.FromSnapshot(new[] {((Piece) white, Position.A1)});
        var board = new GameBoard("ID", configuration, _participants.All);

        var result = board.Move(_participants.White, Position.A1, Position.B2);

        Assert.That(result.IsSuccess);
        Assert.That(board.GameState.CurrentPlayer, Is.EqualTo(Color.Black));
        Assert.That(board.GameState.Log, Is.EqualTo(new[] {new Move(white, Position.A1, Position.B2)}));
    }

    [Test]
    public void GameStateAfterBlackPieceMove()
    {
        var black = new Man("B8", Color.Black);
        var white = new Man("A3", Color.White);

        var pieces = new[] {((Piece) black, Position.B8), ((Piece) white, Position.B4)};
        var moveLog = new[] {new Move(white, Position.A3, Position.B4)};

        var configuration = ClassicConfiguration.FromSnapshot(pieces, moveLog);
        var board = new GameBoard("ID", configuration, _participants.All);

        var result = board.Move(_participants.Black, Position.B8, Position.A7);

        Assert.That(result.IsSuccess);
        Assert.That(board.GameState.CurrentPlayer, Is.EqualTo(Color.White));
        Assert.That(board.GameState.Log, Is.EqualTo(new[] {new Move(white, Position.A3, Position.B4), new Move(black, Position.B8, Position.A7)}));
    }
}