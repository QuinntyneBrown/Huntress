using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Huntress.Api.Models;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;

namespace Huntress.Api.Features
{
    public class RemoveCssVariable
    {
        public class Request : IRequest<Response>
        {
            public Guid CssVariableId { get; set; }
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
                var cssVariable = await _context.CssVariables.SingleAsync(x => x.CssVariableId == request.CssVariableId);

                _context.CssVariables.Remove(cssVariable);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    CssVariable = cssVariable.ToDto()
                };
            }

        }
    }
}
