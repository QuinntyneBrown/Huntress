using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class UpdateCssVariable
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.CssVariable).NotNull();
                RuleFor(request => request.CssVariable).SetValidator(new CssVariableValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public CssVariableDto CssVariable { get; set; }
        }

        public class Response : ResponseBase
        {
            public CssVariableDto CssVariable { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;

            public Handler(IHuntressDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var cssVariable = await _context.CssVariables.SingleAsync(x => x.CssVariableId == request.CssVariable.CssVariableId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    CssVariable = cssVariable.ToDto()
                };
            }

        }
    }
}
