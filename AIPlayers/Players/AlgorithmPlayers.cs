using AIPlayers.MessageHub;
using Microsoft.Extensions.DependencyInjection;

namespace AIPlayers.Players;

public class AlgorithmPlayers(IEnumerable<Algorithm> algorithms, IServiceProvider serviceProvider) : AlgorithmConfiguration, AlgorithmPlayerFactory, AIAlgorithmFactory
{
    public IEnumerable<AIPlayer> Available => algorithms.Select(x => new AIPlayer(x.Name, x.Name));

    public AlgorithmPlayer? Create(string id, string algorithm, Dictionary<string, string> configuration)
    {
        var matchedAlgorithm = algorithms.FirstOrDefault(x => x.Name == algorithm);
        if (matchedAlgorithm is null)
        {
            return null;
        }
        
        return new AlgorithmPlayer(id, algorithm, configuration);
    }

    public AIAlgorithm Create(AlgorithmPlayer player)
    {
        var type = algorithms.FirstOrDefault(x => x.Name == player.Algorithm);
        if (type is null)
        {
            throw new ArgumentException("Algorithm not found");
        }

        return (AIAlgorithm) serviceProvider.GetRequiredService(type.Value);
    }
}