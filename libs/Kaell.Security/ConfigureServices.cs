using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Kaell.Security;

public static class ServiceCollectionExtensions
{
    public static void AddSecurity(this IServiceCollection services)
    {
        services.TryAddSingleton<IPasswordHasher, PasswordHasher>();
        services.TryAddSingleton<ITokenProvider, TokenProvider>();
    }
}
