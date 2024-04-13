using Domain.Shared;

namespace Domain.Chessboard;

public class Participants(IEnumerable<Participant> participants)
{
    public bool Participates(Player player) => participants.Any(x => x.Player.Id == player.Id);
    public Participant? For(Player player) => participants.FirstOrDefault(x => x.Player.Id == player.Id);
    public IEnumerable<Participant> List => participants;
}