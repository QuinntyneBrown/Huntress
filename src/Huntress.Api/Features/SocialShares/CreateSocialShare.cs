using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Domain.Entities;
using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;

namespace Huntress.Api.Features
{
    public class CreateSocialShare
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
                var socialShare = new SocialShare(request.SocialShare.ShareType, request.SocialShare.Url);

                _context.SocialShares.Add(socialShare);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    SocialShare = socialShare.ToDto()
                };
            }

        }
    }
}
