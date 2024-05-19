using AIPlayers.Algorithms.AnthropicClaude;
using AIPlayers.Algorithms.Dummy;
using AIPlayers.Algorithms.OpenAIGpt4o;
using AIPlayers.Algorithms.OpenAIGpt4Turbo;
using AIPlayers.MessageHub;
using AIPlayers.Players;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AIPlayers.Extensions;

public static class ServiceCollectionExtension
{
    
    public static void AddAiPlayer<T>(this IServiceCollection services) where T : class, AIAlgorithm
    {
        services.TryAddAiPlayersInfrastructure();
        
        services.AddTransient<AIAlgorithm, T>(x => x.GetRequiredService<T>());
        services.AddTransient<T>();
    }

    private static void TryAddAiPlayersInfrastructure(this IServiceCollection services)
    {
        services.TryAddTransient<AlgorithmConfiguration>(x => x.GetRequiredService<AlgorithmPlayers>());
        services.TryAddTransient<AlgorithmPlayerFactory>(x => x.GetRequiredService<AlgorithmPlayers>());
        services.TryAddTransient<AIAlgorithmFactory>(x => x.GetRequiredService<AlgorithmPlayers>());
        services.TryAddTransient<AlgorithmPlayers>(p =>
        {
            var aiAlgorithms = p.GetRequiredService<IEnumerable<AIAlgorithm>>();
            var algorithms = aiAlgorithms.Select(x => new Algorithm(x.GetType())); //
            var serviceProvider = p.GetRequiredService<IServiceProvider>();
            return new AlgorithmPlayers(algorithms, serviceProvider);
        });
    }
    
}