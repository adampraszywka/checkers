using System.Text.RegularExpressions;
using Domain.Chessboard;
using Domain.Lobby;
using Domain.Lobby.Errors;
using Domain.Shared;
using NSubstitute;

namespace DomainTests.Lobby;

public class GameLobbyTests
{
    private static bool MatchParticipants(IEnumerable<Participant> expected, IEnumerable<Participant> actual)
    {
        Assert.That(actual, Is.EquivalentTo(expected));
        return true;
    } 
    
    private static (BoardFactory Factory, Board Board) MockedFactory(string boardId, IEnumerable<Participant> expectedParticipants)
    {
        var board = Substitute.For<Board>();
        board.Id.Returns(boardId);
        var factory = Substitute.For<BoardFactory>();
        factory.Create(Arg.Is<IEnumerable<Participant>>(x => MatchParticipants(expectedParticipants, x))).Returns(board);
        
        return (factory, board);
    }
    
    [Test]
    public void NoParticipantsReturnsNull()
    {
        var lobby = new GameLobby("ID", "Name");

        Assert.That(lobby.Id, Is.EqualTo("ID"));
        Assert.That(lobby.Name, Is.EqualTo("Name"));
        Assert.That(lobby.MaxPlayers, Is.EqualTo(2));
        Assert.That(lobby.GameId, Is.Null);
        Assert.That(lobby.Participants, Is.Empty);
    }

    [Test]
    public void FirstPlayerIsWhitePlayer()
    {
        var lobby = new GameLobby("ID", "Name");
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
        var lobby = new GameLobby("ID", "Name");
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
        var lobby = new GameLobby("ID", "Name");
    
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

    [Test]
    public void CloseLobbyWithTwoPlayers()
    {
        var lobby = new GameLobby("LOBBY_ID", "Name");
        var (factory, board) = MockedFactory("GAME_ID", lobby.Participants);
        
        var white = new TestPlayer("W");
        var black = new TestPlayer("B");
        
        Assert.That(lobby.Join(white).IsSuccess);
        Assert.That(lobby.Join(black).IsSuccess);
        
        var close = lobby.Close(white, factory);
        Assert.That(close.IsSuccess);
        Assert.That(close.Value, Is.SameAs(board));
    }

    [Test]
    public void CannotCloseEmptyLobby()
    {
        var lobby = new GameLobby("ID", "Name");
        var (factory, _) = MockedFactory("ID", lobby.Participants);

        var player = new TestPlayer("?");
        
        var result = lobby.Close(player, factory);
        
        Assert.That(result.HasError<PlayerDoesNotParticipate>());
    }
    
    [Test]
    public void CannotCloseLobbyWithSinglePlayer()
    {
        var lobby = new GameLobby("ID", "Name");
        var (factory, _) = MockedFactory("ID", lobby.Participants);

        var player = new TestPlayer("W");
        Assert.That(lobby.Join(player).IsSuccess);
        
        var result = lobby.Close(player, factory);
        Assert.That(result.HasError<NotEnoughPlayers>());
    }

    [Test]
    public void CannotCloseClosedLobby()
    {
        var lobby = new GameLobby("ID", "Name");
        var (factory, _) = MockedFactory("ID", lobby.Participants);
        
        var white = new TestPlayer("W");
        var black = new TestPlayer("B");
        
        Assert.That(lobby.Join(white).IsSuccess);
        Assert.That(lobby.Join(black).IsSuccess);
        Assert.That(lobby.Close(black, factory).IsSuccess);

        var secondClose = lobby.Close(white, factory);
        Assert.That(secondClose.HasError<AlreadyClosed>());
    }

    [Test]
    public void CannotJoinToClosedLobby()
    {
        var lobby = new GameLobby("ID", "Name");
        var (factory, _) = MockedFactory("ID", lobby.Participants);
        
        var white = new TestPlayer("W");
        var black = new TestPlayer("B");
        var third = new TestPlayer("B");
        
        Assert.That(lobby.Join(white).IsSuccess);
        Assert.That(lobby.Join(black).IsSuccess);
        Assert.That(lobby.Close(white, factory).IsSuccess);

        var thirdJoin = lobby.Join(third);
        Assert.That(thirdJoin.HasError<AlreadyClosed>());

    }
    
    private record TestPlayer(string Id) : Player;
}