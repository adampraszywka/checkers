namespace AIPlayers.MessageHub;

public record ScopedConfiguration : AiAlgorithmConfiguration
{
    private Dictionary<string, string>? _entries;

    public Dictionary<string, string> Entries => _entries ?? throw new InvalidOperationException("Configuration is not set");
    
    public void Configure(Dictionary<string,string> entries)
    {
        if (_entries is not null)
        {
            throw new InvalidOperationException("Configuration is already set");
        }
        
        _entries = entries;
    }
}