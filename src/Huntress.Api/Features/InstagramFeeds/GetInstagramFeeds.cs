using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class GetInstagramFeeds
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public List<InstagramFeedDto> InstagramFeeds { get; set; }
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
                    InstagramFeeds = await _context.InstagramFeeds.Select(x => x.ToDto()).ToListAsync()
                };
            }

        }
    }
}
