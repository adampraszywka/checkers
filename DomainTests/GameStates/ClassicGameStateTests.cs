using Domain.GameStates;
using Domain.Pieces;
using Domain.Pieces.Classic;
using P = Domain.Position;
using M = Domain.GameStates.Move;
namespace DomainTests.GameStates;

public class ClassicGameStateTests
{
        public static IEnumerable<IEnumerable<Move>> BlackMovesAfterWhiteTestCases
    {
        get
        {
            yield return [new M(new Man("1", Color.White), P.A1, P.B2)];
            yield return [new M(new King("1", Color.White), P.A1, P.B2)];
            
            //These moves are invalid but to be safe keep them there
            yield return [new M(new Man("1", Color.White), P.A1, P.B2), new M(new Man("2", Color.White), P.A3, P.B4)];
            yield return [new M(new King("1", Color.White), P.A1, P.B2), new M(new King("2", Color.White), P.A3, P.B4)];
            yield return [new M(new Man("1", Color.White), P.A1, P.B2), new M(new King("2", Color.White), P.A3, P.B4)];
            yield return [new M(new King("1", Color.White), P.A1, P.B2), new M(new Man("2", Color.White), P.A3, P.B4)];
            
            // WBW
            yield return [new M(new Man("1", Color.White), P.A1, P.B2), new M(new Man("2", Color.Black), P.B8, P.A7), new M(new Man("3", Color.White), P.A3, P.D4)];
            yield return [new M(new Man("1", Color.White), P.A1, P.B2), new M(new King("2", Color.Black), P.B8, P.A7), new M(new Man("3", Color.White), P.A3, P.D4)];
            yield return [new M(new Man("1", Color.White), P.A1, P.B2), new M(new King("2", Color.Black), P.B8, P.A7), new M(new King("3", Color.White), P.A3, P.D4)];
            yield return [new M(new Man("1", Color.White), P.A1, P.B2), new M(new Man("2", Color.Black), P.B8, P.A7), new M(new King("3", Color.White), P.A3, P.D4)];
            yield return [new M(new King("1", Color.White), P.A1, P.B2), new M(new Man("2", Color.Black), P.B8, P.A7), new M(new Man("3", Color.White), P.A3, P.D4)];
            yield return [new M(new King("1", Color.White), P.A1, P.B2), new M(new King("2", Color.Black), P.B8, P.A7), new M(new Man("3", Color.White), P.A3, P.D4)];
            yield return [new M(new King("1", Color.White), P.A1, P.B2), new M(new King("2", Color.Black), P.B8, P.A7), new M(new King("3", Color.White), P.A3, P.D4)];
        }
    }
    
    public static IEnumerable<IEnumerable<Move>> WhiteMovesAfterBlackTestCases
    {
        get
        {
            yield return [new M(new Man("1", Color.Black), P.A1, P.B2)];
            yield return [new M(new King("1", Color.Black), P.A1, P.B2)];
            
            //These moves are invalid but to be safe keep them there
            yield return [new M(new Man("1", Color.Black), P.B8, P.A7), new M(new Man("2", Color.Black), P.D8, P.C7)];
            yield return [new M(new King("1", Color.Black), P.B8, P.A7), new M(new King("2", Color.Black), P.D8, P.C7)];
            yield return [new M(new Man("1", Color.Black), P.B8, P.A7), new M(new King("2", Color.Black), P.D8, P.C7)];
            yield return [new M(new King("1", Color.Black), P.B8, P.A7), new M(new Man("2", Color.Black), P.D8, P.C7)];
            
            
            // WB
            yield return [new M(new Man("1", Color.White), P.A1, P.B2), new M(new Man("2", Color.Black), P.B8, P.A7)];
            yield return [new M(new Man("1", Color.White), P.A1, P.B2), new M(new King("2", Color.Black), P.B8, P.A7)];    
            yield return [new M(new King("1", Color.White), P.A1, P.B2), new M(new Man("2", Color.Black), P.B8, P.A7)];
            yield return [new M(new King("1", Color.White), P.A1, P.B2), new M(new King("2", Color.Black), P.B8, P.A7)];    
        }
    }
    
    [Test]
    public void FirstMoveDoneByWhite()
    {
        var state = ClassicGameState.New;
        var snapshot = state.Snapshot;
        
        Assert.That(snapshot.CurrentPlayer, Is.EqualTo(Color.White));
        Assert.That(snapshot.Log, Is.Empty);
    }
    
    [Test]
    [TestCaseSource(nameof(BlackMovesAfterWhiteTestCases))]
    public void BlackMovesAfterWhite(IEnumerable<M> log)
    {
        var state = ClassicGameState.FromSnapshot(log);
        var snapshot = state.Snapshot;
        
        Assert.That(snapshot.CurrentPlayer, Is.EqualTo(Color.Black));
        Assert.That(snapshot.Log, Is.EqualTo(log));
    }
    
    [Test]
    [TestCaseSource(nameof(BlackMovesAfterWhiteTestCases))]
    public void BlackManMoveAllowedWhiteNotAllowed(IEnumerable<M> log)
    {
        var state = ClassicGameState.FromSnapshot(log);
        var snapshot = state.Snapshot;

        var white = new Man("W", Color.White);
        var black = new Man("B", Color.Black);
        
        Assert.That(state.IsMoveAllowed(white), Is.False);
        Assert.That(state.IsMoveAllowed(black), Is.True);
        Assert.That(snapshot.CurrentPlayer, Is.EqualTo(Color.Black));
        Assert.That(snapshot.Log, Is.EqualTo(log));
    }
    
    [Test]
    [TestCaseSource(nameof(BlackMovesAfterWhiteTestCases))]
    public void BlackKingMoveAllowedWhiteNotAllowed(IEnumerable<M> log)
    {
        var state = ClassicGameState.FromSnapshot(log);
        var snapshot = state.Snapshot;

        var white = new King("W", Color.White);
        var black = new King("B", Color.Black);
        
        Assert.That(state.IsMoveAllowed(white), Is.False);
        Assert.That(state.IsMoveAllowed(black), Is.True);
        Assert.That(snapshot.CurrentPlayer, Is.EqualTo(Color.Black));
        Assert.That(snapshot.Log, Is.EqualTo(log));
    }
    
    [Test]
    [TestCaseSource(nameof(WhiteMovesAfterBlackTestCases))]
    public void WhiteMovesAfterBlack(IEnumerable<M> log)
    {
        var state = ClassicGameState.FromSnapshot(log);
        var snapshot = state.Snapshot;
        
        Assert.That(snapshot.CurrentPlayer, Is.EqualTo(Color.White));
        Assert.That(snapshot.Log, Is.EqualTo(log));
    }
    
    [Test]
    [TestCaseSource(nameof(WhiteMovesAfterBlackTestCases))]
    public void WhiteManMoveAllowedBlackNotAllowed(IEnumerable<M> log)
    {
        var state = ClassicGameState.FromSnapshot(log);
        var snapshot = state.Snapshot;
        
        var white = new Man("W", Color.White);
        var black = new Man("B", Color.Black);
        
        Assert.That(snapshot.CurrentPlayer, Is.EqualTo(Color.White));
        Assert.That(snapshot.Log, Is.EqualTo(log));
        Assert.That(state.IsMoveAllowed(white), Is.True);
        Assert.That(state.IsMoveAllowed(black), Is.False);
    }
    
    [Test]
    [TestCaseSource(nameof(WhiteMovesAfterBlackTestCases))]
    public void WhiteKingMoveAllowedBlackNotAllowed(IEnumerable<M> log)
    {
        var state = ClassicGameState.FromSnapshot(log);
        var snapshot = state.Snapshot;
        
        var white = new King("W", Color.White);
        var black = new King("B", Color.Black);
        
        Assert.That(state.IsMoveAllowed(white), Is.True);
        Assert.That(state.IsMoveAllowed(black), Is.False);
        Assert.That(snapshot.CurrentPlayer, Is.EqualTo(Color.White));
        Assert.That(snapshot.Log, Is.EqualTo(log));
    }
    
    [Test]
    public void BlackMovesAfterRegisteredMoveOfWhite()
    {
        var state = ClassicGameState.New;
        
        var black = new Man("B", Color.Black);
        var white = new Man("W", Color.White);
        
        state.RegisterMove(white, P.A1, P.B2);

        var snapshot = state.Snapshot;
        Assert.That(state.IsMoveAllowed(white), Is.False);
        Assert.That(state.IsMoveAllowed(black), Is.True);
        Assert.That(snapshot.CurrentPlayer, Is.EqualTo(Color.Black));
        Assert.That(snapshot.Log, Is.EqualTo(new [] {new Move(white, P.A1, P.B2)}));
    }
    
    [Test]
    public void WhiteMovesAfterRegisteredMoveOfBlack()
    {
        var state = ClassicGameState.New;
        
        var black = new Man("B", Color.Black);
        var white = new Man("W", Color.White);
        
        state.RegisterMove(black, P.B8, P.A7);

        var snapshot = state.Snapshot;
        Assert.That(state.IsMoveAllowed(white), Is.True);
        Assert.That(state.IsMoveAllowed(black), Is.False);
        Assert.That(snapshot.CurrentPlayer, Is.EqualTo(Color.White));
        Assert.That(snapshot.Log, Is.EqualTo(new [] {new Move(black, P.B8, P.A7)}));
    }
}