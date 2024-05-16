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

    private record TestPlayer(string Id) : Player
    {
        public string Type => "Test";
        public bool Bot => false;
    }
}

public record AllParticipants(Player White, Player Black, Player NotParticipating, IEnumerable<Participant> All);
