// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using IdentityService.Core;
using IdentityService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services){

        services.AddSingleton<IIdentityServiceDbContext, IdentityServiceDbContext>();
        services.AddDbContext<IdentityServiceDbContext>(o =>
        {
            o.UseSqlServer(x =>
            {

            });
        });
    }

}


