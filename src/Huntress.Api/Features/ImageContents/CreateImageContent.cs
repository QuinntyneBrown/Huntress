using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Models;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;

namespace Huntress.Api.Features
{
    public class CreateImageContent
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.ImageContent).NotNull();
                RuleFor(request => request.ImageContent).SetValidator(new ImageContentValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public ImageContentDto ImageContent { get; set; }
        }

        public class Response : ResponseBase
        {
            public ImageContentDto ImageContent { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;

            public Handler(IHuntressDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var imageContent = new ImageContent(
                    request.ImageContent.ImageContentType,
                    request.ImageContent.Url);

                _context.ImageContents.Add(imageContent);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    ImageContent = imageContent.ToDto()
                };
            }

        }
    }
}
