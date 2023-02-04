using IdentityService.Api;
using IdentityService.Core;
using MediatR;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices { 
    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddHostedService<ServiceBusWorker>();
        services.AddMediatR(typeof(IIdentityServiceDbContext));
        services.AddMessagingUdpServices();
    }
}