using Domain.Chessboard;

namespace WebApi.Players;

public interface NotifiablePlayer
{
    public Task Notify(BoardSnapshot snapshot);
}