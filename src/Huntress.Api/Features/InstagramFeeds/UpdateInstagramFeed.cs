using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class UpdateInstagramFeed
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.InstagramFeed).NotNull();
                RuleFor(request => request.InstagramFeed).SetValidator(new InstagramFeedValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public InstagramFeedDto InstagramFeed { get; set; }
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
                var instagramFeed = await _context.InstagramFeeds.SingleAsync(x => x.InstagramFeedId == request.InstagramFeed.InstagramFeedId);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    InstagramFeed = instagramFeed.ToDto()
                };
            }

        }
    }
}
