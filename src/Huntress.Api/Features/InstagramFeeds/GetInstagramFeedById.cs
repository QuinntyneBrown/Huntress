using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class GetInstagramFeedById
    {
        public class Request : IRequest<Response>
        {
            public Guid InstagramFeedId { get; set; }
        }

        public class Response : ResponseBase
        {
            public InstagramFeedDto InstagramFeed { get; set; }
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
                    InstagramFeed = (await _context.InstagramFeeds.SingleOrDefaultAsync(x => x.InstagramFeedId == request.InstagramFeedId)).ToDto()
                };
            }

        }
    }
}
