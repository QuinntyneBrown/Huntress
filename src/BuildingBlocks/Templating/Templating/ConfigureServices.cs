// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Templating;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddTemplatingServices(this IServiceCollection services)
    { 
        services.AddScoped<INamingConventionConverter, NamingConventionConverter>();
        services.AddScoped<IStaticFileLocator, StaticFileLocator>();
    }
}