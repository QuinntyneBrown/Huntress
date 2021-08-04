using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class UpdateSocialShare
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.SocialShare).NotNull();
                RuleFor(request => request.SocialShare).SetValidator(new SocialShareValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public SocialShareDto SocialShare { get; set; }
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
                var socialShare = await _context.SocialShares.SingleAsync(x => x.SocialShareId == request.SocialShare.SocialShareId);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    SocialShare = socialShare.ToDto()
                };
            }

        }
    }
}
