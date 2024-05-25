using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace AIPlayers.Extensions;

public static class ServiceProviderExtensions
{
    public static IEnumerable<Type> RegisteredAs<T> (this IServiceProvider provider)
    {
        var providerType = provider.GetType();
        
        if (providerType.Name == "ServiceProviderEngineScope")
        {
            var rootProvider = providerType.GetProperty("RootProvider", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(provider);
            if (rootProvider is null)
            {
                throw new InvalidOperationException("Could not get RootProvider from ServiceProviderEngineScope");
            }

            if (rootProvider is ServiceProvider rootServiceProvider)
            {
                return ExtractFromRootProvider<T>(rootServiceProvider);
            }
            
        }
        
        if (provider is ServiceProvider serviceProvider)
        {
            return ExtractFromRootProvider<T>(serviceProvider);
        }
        
        throw new NotSupportedException("This method is only supported for ServiceProvider");
    }

    private static IEnumerable<Type> ExtractFromRootProvider<T>(ServiceProvider provider)
    {
        var callSiteFactory = typeof(ServiceProvider).GetProperty("CallSiteFactory", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(provider);
        if (callSiteFactory is null)
        {
            throw new InvalidOperationException("Could not get CallSiteFactory");
        }

        if (callSiteFactory.GetType().GetField("_descriptors", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(callSiteFactory) is not ServiceDescriptor[] descriptors)
        {
            throw new InvalidOperationException("Could not get descriptors from CallSiteFactory");
        }

        return descriptors
            .Where(x => x.ServiceType.IsAssignableTo(typeof(T)))
            .Where(x => x.ServiceType != typeof(T))
            .Select(x => x.ServiceType);
    }
}