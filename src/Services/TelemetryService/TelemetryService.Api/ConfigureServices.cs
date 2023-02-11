// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using TelemetryService.Api;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddSignalR();
        services.AddMessagingUdpServices();
        services.AddHostedService<ServiceBusMessageConsumer>();
    }
}