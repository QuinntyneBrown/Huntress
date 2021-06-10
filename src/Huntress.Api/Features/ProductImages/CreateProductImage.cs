using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Models;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;

namespace Huntress.Api.Features
{
    public class CreateProductImage
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.ProductImage).NotNull();
                RuleFor(request => request.ProductImage).SetValidator(new ProductImageValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public ProductImageDto ProductImage { get; set; }
        }

        public class Response: ResponseBase
        {
            public ProductImageDto ProductImage { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;
        
            public Handler(IHuntressDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var productImage = new ProductImage(request.ProductImage.Name,request.ProductImage.ImageUrl);
                
                _context.ProductImages.Add(productImage);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    ProductImage = productImage.ToDto()
                };
            }
            
        }
    }
}
