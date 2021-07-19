using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Models;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;

namespace Huntress.Api.Features
{
    public class CreateProductUpdateRequest
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.ProductUpdateRequest).NotNull();
                RuleFor(request => request.ProductUpdateRequest).SetValidator(new ProductUpdateRequestValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public ProductUpdateRequestDto ProductUpdateRequest { get; set; }
        }

        public class Response: ResponseBase
        {
            public ProductUpdateRequestDto ProductUpdateRequest { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;
        
            public Handler(IHuntressDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var productUpdateRequest = new ProductUpdateRequest(
                    request.ProductUpdateRequest.Email,
                    request.ProductUpdateRequest.ProductId);
                
                _context.ProductUpdateRequests.Add(productUpdateRequest);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    ProductUpdateRequest = productUpdateRequest.ToDto()
                };
            }
            
        }
    }
}
