using Domain.Chessboard;
using Domain.Shared;

namespace Domain.Lobby;

public interface BoardFactory
{
    public Board Create(IEnumerable<Participant> participants);
} 