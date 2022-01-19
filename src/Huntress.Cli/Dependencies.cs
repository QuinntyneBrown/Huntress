using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Huntress.Cli
{
    internal class Dependencies
    {
        internal static void Configure(IServiceCollection services)
        {
            services.AddMediatR(typeof(Program));
            services.AddScoped<ICommandService, CommandService>();
        }
    }
}
