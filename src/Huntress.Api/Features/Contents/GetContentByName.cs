using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Huntress.Api.Features
{
    public class GetContentByName
    {
        public class Request : IRequest<Response>
        {
            public string Name { get; set; }
        }

        public class Response : ResponseBase
        {
            public ContentDto Content { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;

            public Handler(IHuntressDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new()
                {
                    Content = (await _context.Contents.SingleOrDefaultAsync(x => x.Name == request.Name)).ToDto()
                };
            }

        }
    }
}
