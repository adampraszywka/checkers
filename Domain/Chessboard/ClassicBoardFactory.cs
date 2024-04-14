using Domain.Chessboard.Configurations.Classic;
using Domain.Lobby;
using Domain.Shared;

namespace Domain.Chessboard;

public class ClassicBoardFactory : BoardFactory
{
    public Board Create(IEnumerable<Participant> participants)
    {
        var id = Guid.NewGuid().ToString();
        var configuration = ClassicConfiguration.NewBoard();

        return new GameBoard(id, configuration, participants);; 
    }
}