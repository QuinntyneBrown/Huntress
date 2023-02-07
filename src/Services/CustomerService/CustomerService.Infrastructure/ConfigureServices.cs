// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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


