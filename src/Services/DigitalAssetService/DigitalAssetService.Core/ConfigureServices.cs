// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using DigitalAssetService.Core;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddCoreServices(this IServiceCollection services){ 
        services.AddHostedService<ServiceBusMessageConsumer>();
    }

}



