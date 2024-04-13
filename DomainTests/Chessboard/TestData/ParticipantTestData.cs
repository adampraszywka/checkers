using Domain.Shared;

namespace DomainTests.Chessboard.TestData;

public static class ParticipantTestData
{
    public static AllParticipants Participants
    {
        get
        {
            var white = new TestPlayer("W");
            var black = new TestPlayer("B");
            var externalPlayer = new TestPlayer("X");
            return new(white, black, externalPlayer, [new Participant(white, Color.White), new Participant(black, Color.Black)]);
        }
    }

    public record TestPlayer(string Id) : Player;
}

public record AllParticipants(Player White, Player Black, Player NotParticipating, IEnumerable<Participant> All);
