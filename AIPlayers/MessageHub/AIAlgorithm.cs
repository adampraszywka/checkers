using Contracts.Dto;

namespace AIPlayers.MessageHub;

public interface AIAlgorithm
{
    public ValueTask Move(ParticipantDto participant, BoardDto board);
}