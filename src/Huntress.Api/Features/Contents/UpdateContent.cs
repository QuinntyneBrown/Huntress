using FluentValidation;
using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Huntress.Api.Features
{
    public class UpdateContent
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
                var content = await _context.Contents.SingleAsync(x => x.ContentId == request.Content.ContentId);

                content.Json = request.Content.Json;

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Content = content.ToDto()
                };
            }
        }
    }
}
