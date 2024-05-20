using AIPlayers.MessageHub;
using AIPlayers.Players;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AIPlayers.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddAIPlayer<T>(this IServiceCollection services, Func<IServiceProvider, T> implementationFactory) where T : class, AIAlgorithm
    {
        services.TryAddAiPlayersInfrastructure();

        services.AddTransient(implementationFactory);
        services.AddTransient<AIAlgorithm, T>(x => x.GetRequiredService<T>());
    }
    
    public static void AddAiPlayer<T>(this IServiceCollection services) where T : class, AIAlgorithm
    {
        services.TryAddAiPlayersInfrastructure();

        services.AddTransient<T>();
        services.AddTransient<AIAlgorithm, T>(x => x.GetRequiredService<T>());
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