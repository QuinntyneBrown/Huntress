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
    public class RemoveInstagramFeedItem
    {
        public class Request: IRequest<Response>
        {
            public Guid InstagramFeedItemId { get; set; }
        }

        public class Response: ResponseBase
        {
            public InstagramFeedItemDto InstagramFeedItem { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;
        
            public Handler(IHuntressDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var instagramFeedItem = await _context.InstagramFeedItems.SingleAsync(x => x.InstagramFeedItemId == request.InstagramFeedItemId);
                
                _context.InstagramFeedItems.Remove(instagramFeedItem);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    InstagramFeedItem = instagramFeedItem.ToDto()
                };
            }
            
        }
    }
}
