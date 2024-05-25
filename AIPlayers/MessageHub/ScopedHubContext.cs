namespace AIPlayers.MessageHub;

public record ScopedHubContext : AiAlgorithmContext
{
    private string? _boardId;
    private string? _playerId;

    private const string AlreadyConfiguredExceptionMessage = "Hub context is already configured";
    private const string NotConfiguredExceptionMessage = "Hub context is not configured";
    
    public string BoardId => _boardId ?? throw new InvalidOperationException(NotConfiguredExceptionMessage);
    public string PlayerId => _playerId ?? throw new InvalidOperationException(NotConfiguredExceptionMessage);

    public void Configure(string boardId, string playerId)
    {
        if (_boardId is not null || _playerId is not null)
        {
            throw new InvalidOperationException(AlreadyConfiguredExceptionMessage);
        }
        
        _boardId = boardId;
        _playerId = playerId;
    }
}