using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Huntress.Api.Models;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;

namespace Huntress.Api.Features
{
    public class RemoveInstagramFeed
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
                var instagramFeed = await _context.InstagramFeeds.SingleAsync(x => x.InstagramFeedId == request.InstagramFeedId);

                _context.InstagramFeeds.Remove(instagramFeed);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    InstagramFeed = instagramFeed.ToDto()
                };
            }

        }
    }
}
