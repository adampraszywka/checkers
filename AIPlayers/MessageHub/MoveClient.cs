using Contracts.Dto;
using FluentResults;

namespace AIPlayers.MessageHub;

public interface MoveClient
{
    public Task<Result> Move(MoveDto move);
}