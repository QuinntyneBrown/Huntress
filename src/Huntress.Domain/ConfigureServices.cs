using Microsoft.Extensions.DependencyInjection;

namespace Huntress.Domain;

public static class ServiceCollectionExtensions
{
    public static void AddDomainServices(this IServiceCollection services)
    {
        services.AddSecurity();
    }
}
