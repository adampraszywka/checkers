using Contracts.Dto;

namespace WebApi.Hubs;

public interface BoardHubClient
{
    public Task BoardUpdated(BoardDto board);
}