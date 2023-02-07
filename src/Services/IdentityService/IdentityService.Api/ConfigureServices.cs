// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using IdentityService.Api;
using IdentityService.Core;
using MediatR;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices { 
    public static void AddApiServices(this IServiceCollection services) {
        services.AddMediatR(typeof(IIdentityServiceDbContext));
        services.AddMessagingUdpServices();
    }
}


