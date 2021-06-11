using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Models;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;

namespace Huntress.Api.Features
{
    public class CreateInstagramFeed
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
                var instagramFeed = new InstagramFeed(request.InstagramFeed.AccountName, request.InstagramFeed.AccountHandle);

                _context.InstagramFeeds.Add(instagramFeed);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    InstagramFeed = instagramFeed.ToDto()
                };
            }

        }
    }
}
