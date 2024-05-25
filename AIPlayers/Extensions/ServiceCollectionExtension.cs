using AIPlayers.MessageHub;
using AIPlayers.Players;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AIPlayers.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddAiPlayer<T>(this IServiceCollection services, Func<IServiceProvider, T> implementationFactory) where T : class, AIAlgorithm
    {
        services.TryAddAiPlayersInfrastructure();

        services.AddTransient(implementationFactory);
    }
    
    public static void AddAiPlayer<T>(this IServiceCollection services) where T : class, AIAlgorithm
    {
        services.TryAddAiPlayersInfrastructure();

        services.AddScoped<T>();
    }

    private static void TryAddAiPlayersInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ScopedHubContext>();
        services.AddScoped<MoveClient, MassTransitMoveClient>();
        services.AddScoped<MassTransitStatusPublisher>();
        services.AddScoped<ScopedConfiguration>();
        services.AddScoped<StatusPublisher>(x => x.GetRequiredService<MassTransitStatusPublisher>());
        services.AddScoped<AiAlgorithmConfiguration>(x => x.GetRequiredService<ScopedConfiguration>());
        
        services.TryAddScoped<AlgorithmConfiguration>(x => x.GetRequiredService<AlgorithmPlayers>());
        services.TryAddScoped<AlgorithmPlayerFactory>(x => x.GetRequiredService<AlgorithmPlayers>());
        services.TryAddScoped<AIAlgorithmFactory>(x => x.GetRequiredService<AlgorithmPlayers>());
        services.TryAddScoped<AlgorithmPlayers>(p =>
        {
            // There were few options to get all registered AIAlgorithms
            // First one was to use IServiceProvider and get all registered services by AiAlgorithm type but there was one huge drawback
            // That approach required to initialize all services, and it was not acceptable
            //
            // Another one was to track registered services by AiAlgorithm type in some kind of collection,
            // but it didn't seem to be a good idea too.
            //
            // The last one was to use reflection to get all registered services by AiAlgorithm type from built DI container
            // It's also not the best solution, but it's the most acceptable one, at least for today's me :)
            // 
            // Anyway, it will probably need to be refactored in the future
            var aiAlgorithms = p.RegisteredAs<AIAlgorithm>();
            var algorithms = aiAlgorithms.Select(x => new Algorithm(x)); //
            var serviceProvider = p.GetRequiredService<IServiceProvider>();
            return new AlgorithmPlayers(algorithms, serviceProvider);
        });
    }
    
}