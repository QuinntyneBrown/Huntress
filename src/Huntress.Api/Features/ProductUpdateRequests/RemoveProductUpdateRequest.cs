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
    public class RemoveProductUpdateRequest
    {
        public class Request : IRequest<Response>
        {
            public Guid ProductUpdateRequestId { get; set; }
        }

        public class Response : ResponseBase
        {
            public ProductUpdateRequestDto ProductUpdateRequest { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;

            public Handler(IHuntressDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var productUpdateRequest = await _context.ProductUpdateRequests.SingleAsync(x => x.ProductUpdateRequestId == request.ProductUpdateRequestId);

                _context.ProductUpdateRequests.Remove(productUpdateRequest);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    ProductUpdateRequest = productUpdateRequest.ToDto()
                };
            }

        }
    }
}
