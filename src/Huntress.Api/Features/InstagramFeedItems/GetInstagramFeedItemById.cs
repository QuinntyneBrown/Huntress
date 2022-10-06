using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class GetInstagramFeedItemById
    {
        public class Request : IRequest<Response>
        {
            public Guid InstagramFeedItemId { get; set; }
        }

        public class Response : ResponseBase
        {
            public InstagramFeedItemDto InstagramFeedItem { get; set; }
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
                    InstagramFeedItem = (await _context.InstagramFeedItems.SingleOrDefaultAsync(x => x.InstagramFeedItemId == request.InstagramFeedItemId)).ToDto()
                };
            }

        }
    }
}
