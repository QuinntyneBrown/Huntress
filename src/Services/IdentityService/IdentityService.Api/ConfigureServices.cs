namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices { 
    public static void AddIdentityApiServices(this IServiceCollection services)
    {
        services.AddMessagingUdpServices();
    }
}
