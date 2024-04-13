using Domain.Lobby;
using Domain.Lobby.Errors;
using Domain.Shared;

namespace DomainTests.Lobby;

public class GameLobbyTests
{
    [Test]
    public void NoParticipantsReturnsNull()
    {
        var lobby = new GameLobby("ID");

        Assert.That(lobby.Id, Is.EqualTo("ID"));
        Assert.That(lobby.Participants, Is.Empty);
    }

    [Test]
    public void FirstPlayerIsWhitePlayer()
    {
        var lobby = new GameLobby("ID");
        var player = new TestPlayer("1");

        var result = lobby.Join(player);
        
        Assert.That(lobby.Participants.Count(), Is.EqualTo(1));
        var participant = lobby.Participants.First();
        
        Assert.That(result.IsSuccess);
        Assert.Multiple(() =>
        {
            Assert.That(participant.Color, Is.EqualTo(Color.White));
            Assert.That(participant.Player, Is.SameAs(player));
        });
    }

    [Test]
    public void SecondPlayerIsBlackPlayer()
    {
        var lobby = new GameLobby("ID");
        var white = new TestPlayer("W");
        var black = new TestPlayer("B");
    
        var whiteJoinResult = lobby.Join(white);
        var blackJoinResult = lobby.Join(black);
    
        Assert.That(lobby.Participants.Count(), Is.EqualTo(2));
        Assert.That(whiteJoinResult.IsSuccess);
        Assert.That(blackJoinResult.IsSuccess);
        
        var whiteParticipant = lobby.Participants.First(x => x.Player.Id == white.Id);
        var blackParticipant = lobby.Participants.First(x => x.Player.Id == black.Id);
    
        Assert.Multiple(() =>
        {
            Assert.That(whiteParticipant.Color, Is.EqualTo(Color.White));
            Assert.That(whiteParticipant.Player, Is.SameAs(white));
        });
    
        Assert.Multiple(() =>
        {
            Assert.That(blackParticipant.Color, Is.EqualTo(Color.Black));
            Assert.That(blackParticipant.Player, Is.SameAs(black));
        });
    }
    
    [Test]
    public void OnlyTwoPlayersCanJoinTheGame()
    {
        var lobby = new GameLobby("ID");
    
        var white = new TestPlayer("W");
        var black = new TestPlayer("B");
        var undefined = new TestPlayer("U");
    
        var whiteJoinResult = lobby.Join(white);
        var blackJoinResult = lobby.Join(black);
        var undefinedJoinResult = lobby.Join(undefined);
    
        Assert.That(whiteJoinResult.IsSuccess);
        Assert.That(blackJoinResult.IsSuccess);
        Assert.That(lobby.Participants.Count(), Is.EqualTo(2));
        Assert.That(undefinedJoinResult.HasError<GameQuotaReached>());
    }
    
    private record TestPlayer(string Id) : Player;
}