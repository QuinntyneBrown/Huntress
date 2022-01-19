using CommandLine;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Huntress.Cli
{
    internal class Default
    {
        [Verb("default")]
        internal class Request : IRequest<Unit> { }

        internal class Handler : IRequestHandler<Request, Unit>
        {
            private readonly ICommandService _commandService;
            public Handler(ICommandService commandService)
            {
                _commandService = commandService;
            }
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                _commandService.Start(@"code .", @"C:\projects\Huntress\src\Huntress.App");
                _commandService.Start(@"start Huntress.Api.csproj", @"C:\projects\Huntress\src\Huntress.Api");

                return new();
            }
        }
    }
}
