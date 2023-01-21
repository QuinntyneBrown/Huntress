using CustomerService.Core;
using CustomerService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services){

        services.AddTransient<ICustomerServiceDbContext, CustomerServiceDbContext>();

        services.AddDbContext<CustomerServiceDbContext>(options =>
        {
            options.UseInMemoryDatabase(nameof(CustomerService))
            .LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging();
        });
    }

}

