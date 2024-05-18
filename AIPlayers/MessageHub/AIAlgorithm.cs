using Contracts.Dto;

namespace AIPlayers.MessageHub;

public interface AIAlgorithm
{
    public Task Move(ParticipantDto participant, BoardDto board, Services services);
}