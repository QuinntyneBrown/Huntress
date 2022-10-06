using FluentValidation;
using Huntress.Domain.Common;
using Huntress.Api.Extensions;
using Huntress.Domain.Interfaces;
using Huntress.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Huntress.Api.Features
{
    public class CreateContent
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Content).NotNull();
                RuleFor(request => request.Content).SetValidator(new ContentValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public ContentDto Content { get; set; }
        }

        public class Response : ResponseBase
        {
            public ContentDto Content { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;

            public Handler(IHuntressDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var content = new Content()
                {
                    Name = request.Content.Name,
                    Json = request.Content.Json,
                    Slug = request.Content.Name.Slugify()
                };

                _context.Contents.Add(content);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Content = content.ToDto()
                };
            }

        }
    }
}
