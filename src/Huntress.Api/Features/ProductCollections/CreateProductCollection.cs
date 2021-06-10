using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Models;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;

namespace Huntress.Api.Features
{
    public class CreateProductCollection
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.ProductCollection).NotNull();
                RuleFor(request => request.ProductCollection).SetValidator(new ProductCollectionValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public ProductCollectionDto ProductCollection { get; set; }
        }

        public class Response: ResponseBase
        {
            public ProductCollectionDto ProductCollection { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;
        
            public Handler(IHuntressDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var productCollection = new ProductCollection(request.ProductCollection.ProductCollectionType);
                
                _context.ProductCollections.Add(productCollection);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    ProductCollection = productCollection.ToDto()
                };
            }
            
        }
    }
}
