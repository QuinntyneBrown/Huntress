using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Models;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;

namespace Huntress.Api.Features
{
    public class CreateHtmlContent
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.HtmlContent).NotNull();
                RuleFor(request => request.HtmlContent).SetValidator(new HtmlContentValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public HtmlContentDto HtmlContent { get; set; }
        }

        public class Response : ResponseBase
        {
            public HtmlContentDto HtmlContent { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;

            public Handler(IHuntressDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var htmlContent = new HtmlContent(
                    request.HtmlContent.HtmlContentType,
                    request.HtmlContent.Name,
                    request.HtmlContent.Body);

                _context.HtmlContents.Add(htmlContent);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    HtmlContent = htmlContent.ToDto()
                };
            }

        }
    }
}
