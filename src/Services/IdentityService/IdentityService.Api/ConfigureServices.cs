using IdentityService.Api;
using IdentityService.Core;
using MediatR;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices { 
    public static void AddApiServices(this IServiceCollection services) {
        services.AddHostedService<Foo>();
        services.AddHostedService<ServiceBusMessageConsumer>();
        services.AddMediatR(typeof(IIdentityServiceDbContext));
        services.AddMessagingUdpServices();
    }
}

