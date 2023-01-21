using CustomerService.Core;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddCoreServices(this IServiceCollection services){

        services.AddMessagingUdpServices();

        services.AddValidation(typeof(ICustomerServiceDbContext));

        services.AddMediatR(typeof(ICustomerServiceDbContext));
    }

}

