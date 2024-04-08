using Domain;
using Domain.Errors.Game;
using Domain.Pieces;
using Domain.Pieces.Classic;

namespace DomainTests;


public class GameTests
{
    private record TestPlayer(string Id) : Player;
    
    [Test]
    public void NewGame()
    {
        var game = new Game("ID", "BID");
        
        Assert.That(game.Id, Is.EqualTo("ID"));
    }

    [Test]
    public void NoParticipantsReturnsNull()
    {
        var game = new Game("ID", "BID");
        
        Assert.That(game.Get(new TestPlayer("123")), Is.Null);
    }

    [Test]
    public void FirstPlayerIsWhitePlayer()
    {
        var game = new Game("ID", "BID");
        var player = new TestPlayer("1");
        
        var result = game.Join(player);
        
        var participant = game.Get(player);
        
        Assert.That(result.IsSuccess);
        Assert.That(participant, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(participant!.Color, Is.EqualTo(Color.White));
            Assert.That(participant!.Id, Is.EqualTo("1"));
        });
    }

    [Test]
    public void SecondPlayerIsBlackPlayer()
    {
        var game = new Game("ID", "BID");
        var white = new TestPlayer("W");
        var black = new TestPlayer("B");
        
        var whiteJoinResult = game.Join(white);
        var blackJoinResult = game.Join(black);
        
        var whiteParticipant = game.Get(white);
        var blackParticipant = game.Get(black);
        
        Assert.That(whiteJoinResult.IsSuccess);
        Assert.That(blackJoinResult.IsSuccess);
        Assert.That(whiteParticipant, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(whiteParticipant!.Color, Is.EqualTo(Color.White));
            Assert.That(whiteParticipant!.Id, Is.EqualTo("W"));
        });
        
        Assert.That(blackParticipant, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(blackParticipant!.Color, Is.EqualTo(Color.Black));
            Assert.That(blackParticipant!.Id, Is.EqualTo("B"));
        });
    }

    [Test]
    public void OnlyTwoPlayersCanJoinTheGame()
    {
        var game = new Game("ID", "BID");
        
        var white = new TestPlayer("W");
        var black = new TestPlayer("B");
        var undefined = new TestPlayer("U");
        
        var whiteJoinResult = game.Join(white);
        var blackJoinResult = game.Join(black);
        var undefinedJoinResult = game.Join(undefined);
        
        Assert.That(whiteJoinResult.IsSuccess);
        Assert.That(blackJoinResult.IsSuccess);
        Assert.That(undefinedJoinResult.HasError<GameQuotaReached>());
    }
    
    [Test]
    public void GameWithoutPlayersNooneParticipates()
    {
        var game = new Game("ID", "BID");
        
        var white = new TestPlayer("W");
        var black = new TestPlayer("B");

        Assert.That(game.DoesParticipate(white), Is.False);
        Assert.That(game.DoesParticipate(black), Is.False);
    }
    
    [Test]
    public void FirstPlayerCannotJoinTwice()
    {
        var game = new Game("ID", "BID");
        
        var white = new TestPlayer("W");
        
        var whiteJoinResult1 = game.Join(white);
        var whiteJoinResult2 = game.Join(white);

        Assert.That(whiteJoinResult1.IsSuccess);
        Assert.That(whiteJoinResult2.HasError<PlayerAlreadyJoined>());
    }

    [Test]
    public void WhitePlayerParticipatesInGame()
    {
        var game = new Game("ID", "BID");
        
        var white = new TestPlayer("W");
        var black = new TestPlayer("B");

        var whiteJoinResult = game.Join(white);
        var blackJoinResult = game.Join(black);

        var participatesFlag = game.DoesParticipate(black);
        
        Assert.That(whiteJoinResult.IsSuccess);
        Assert.That(blackJoinResult.IsSuccess);
        Assert.That(participatesFlag, Is.True);
    }
    
    [Test]
    public void BlackPlayerParticipatesInGame()
    {
        var game = new Game("ID", "BID");
        
        var white = new TestPlayer("W");
        var whiteJoinResult = game.Join(white);

        var participatesFlag = game.DoesParticipate(white);
        
        Assert.That(whiteJoinResult.IsSuccess);
        Assert.That(participatesFlag, Is.True);
    }

    public static IEnumerable<Piece> WhitePieces
    {
        get
        {
            yield return new Man("ID", Color.White);
            yield return new King("ID", Color.White);
        }
    }
    
    public static IEnumerable<Piece> BlackPieces
    {
        get
        {
            yield return new Man("ID", Color.Black);
            yield return new King("ID", Color.Black);
        }
    }
    
    [Test]
    [TestCaseSource(nameof(WhitePieces))]
    public void WhitePlayerCanMoveWhitePieces(Piece piece)
    {
        var game = new Game("ID", "BID");
        
        var white = new TestPlayer("W");

        game.Join(white);
        
        var participant = game.Get(white);
        
        Assert.That(participant, Is.Not.Null);
        Assert.That(participant!.CanMove(piece), Is.True);
    }
    
    [Test]
    [TestCaseSource(nameof(BlackPieces))]
    public void WhitePlayerCannotMoveBlackPieces(Piece piece)
    {
        var game = new Game("ID", "BID");
        
        var white = new TestPlayer("W");

        game.Join(white);
        
        var participant = game.Get(white);
        
        Assert.That(participant, Is.Not.Null);
        Assert.That(participant!.CanMove(piece), Is.False);
    }
    
    [Test]
    [TestCaseSource(nameof(BlackPieces))]
    public void BlackPlayerCanMoveBlackPieces(Piece piece)
    {
        var game = new Game("ID", "BID");
        var black = new TestPlayer("B");

        game.Join(new TestPlayer("W"));
        game.Join(black);
        
        var participant = game.Get(black);
        
        Assert.That(participant, Is.Not.Null);
        Assert.That(participant!.CanMove(piece), Is.True);
    }
    
    [Test]
    [TestCaseSource(nameof(WhitePieces))]
    public void BlackPlayerCannotMoveWhitePieces(Piece piece)
    {
        var game = new Game("ID", "BID");
        var black = new TestPlayer("B");

        game.Join(new TestPlayer("W"));
        game.Join(black);
        
        var participant = game.Get(black);
        
        Assert.That(participant, Is.Not.Null);
        Assert.That(participant!.CanMove(piece), Is.False);
    }
}