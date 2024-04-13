using Domain.Chessboard;
using DomainTests.Chessboard.TestData;

namespace DomainTests.Chessboard;

public class ParticipantsTests
{
    [Test]
    public void Participates()
    {
        var data = ParticipantTestData.Participants;
        var participants = new Participants(data.All);
        
        Assert.That(participants.Participates(data.Black), Is.True);
        Assert.That(participants.Participates(data.White), Is.True);
    }
    
    [Test]
    public void DoesNotParticipate()
    {
        var data = ParticipantTestData.Participants;
        var participants = new Participants(data.All);
        
        Assert.That(participants.Participates(data.NotParticipating), Is.False);
    }
}