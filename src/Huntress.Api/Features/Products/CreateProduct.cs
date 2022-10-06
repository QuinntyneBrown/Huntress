using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Domain.Entities;
using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;

namespace Huntress.Api.Features
{
    public class CreateProduct
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Product).NotNull();
                RuleFor(request => request.Product).SetValidator(new ProductValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public ProductDto Product { get; set; }
        }

        public class Response : ResponseBase
        {
            public ProductDto Product { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;

            public Handler(IHuntressDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var product = new Product(
                    request.Product.Name,
                    request.Product.Price,
                    request.Product.Description);

                _context.Products.Add(product);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Product = product.ToDto()
                };
            }

        }
    }
}
