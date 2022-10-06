using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class UpdateProductUpdateRequest
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.ProductUpdateRequest).NotNull();
                RuleFor(request => request.ProductUpdateRequest).SetValidator(new ProductUpdateRequestValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public ProductUpdateRequestDto ProductUpdateRequest { get; set; }
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
                var productUpdateRequest = await _context.ProductUpdateRequests.SingleAsync(x => x.ProductUpdateRequestId == request.ProductUpdateRequest.ProductUpdateRequestId);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    ProductUpdateRequest = productUpdateRequest.ToDto()
                };
            }

        }
    }
}
