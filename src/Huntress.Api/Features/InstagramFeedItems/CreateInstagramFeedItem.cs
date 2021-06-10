using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Models;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;

namespace Huntress.Api.Features
{
    public class CreateInstagramFeedItem
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.InstagramFeedItem).NotNull();
                RuleFor(request => request.InstagramFeedItem).SetValidator(new InstagramFeedItemValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public InstagramFeedItemDto InstagramFeedItem { get; set; }
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
                var instagramFeedItem = new InstagramFeedItem(request.InstagramFeedItem.ImageUrl, request.InstagramFeedItem.HtmlBody);
                
                _context.InstagramFeedItems.Add(instagramFeedItem);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    InstagramFeedItem = instagramFeedItem.ToDto()
                };
            }
            
        }
    }
}
