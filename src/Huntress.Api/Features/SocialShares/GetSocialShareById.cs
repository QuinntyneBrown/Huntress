using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class GetSocialShareById
    {
        public class Request : IRequest<Response>
        {
            public Guid SocialShareId { get; set; }
        }

        public class Response : ResponseBase
        {
            public SocialShareDto SocialShare { get; set; }
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
                    SocialShare = (await _context.SocialShares.SingleOrDefaultAsync(x => x.SocialShareId == request.SocialShareId)).ToDto()
                };
            }

        }
    }
}
