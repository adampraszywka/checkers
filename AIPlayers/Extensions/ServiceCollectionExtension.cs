using AIPlayers.Algorithms.AnthropicClaude;
using AIPlayers.Algorithms.Dummy;
using AIPlayers.Algorithms.OpenAIGpt4o;
using AIPlayers.Algorithms.OpenAIGpt4Turbo;
using AIPlayers.MessageHub;
using AIPlayers.Players;
using Microsoft.Extensions.DependencyInjection;

namespace AIPlayers.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddAIPlayers(this IServiceCollection services)
    {
        services.AddScoped<AlgorithmPlayers>();
        services.AddScoped<AlgorithmConfiguration>(x => x.GetRequiredService<AlgorithmPlayers>());
        services.AddScoped<AlgorithmPlayerFactory>(x => x.GetRequiredService<AlgorithmPlayers>());
        services.AddScoped<AIAlgorithmFactory>(x => x.GetRequiredService<AlgorithmPlayers>());
        
        services.AddTransient<AntrophicClaude>();
        services.AddTransient<DummyAi>();
        services.AddTransient<OpenAiGpt4o>();
        services.AddTransient<OpenAiGpt4Turbo>();

        services.AddTransient<AlgorithmPlayers>(x =>
        {
            var algorithms = new List<Algorithm>
            {
                new(typeof(DummyAi)),
                new(typeof(OpenAiGpt4o)),
                new(typeof(OpenAiGpt4Turbo)),
                new(typeof(AntrophicClaude)),
            };
    
            var serviceProvider = x.GetRequiredService<IServiceProvider>();
            return new AlgorithmPlayers(algorithms, serviceProvider);
        });
    }
}