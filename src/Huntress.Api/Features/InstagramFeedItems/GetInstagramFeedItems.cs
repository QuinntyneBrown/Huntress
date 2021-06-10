using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class GetInstagramFeedItems
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<InstagramFeedItemDto> InstagramFeedItems { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;
        
            public Handler(IHuntressDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    InstagramFeedItems = await _context.InstagramFeedItems.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
