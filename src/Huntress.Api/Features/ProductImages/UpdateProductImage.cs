using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class UpdateProductImage
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.ProductImage).NotNull();
                RuleFor(request => request.ProductImage).SetValidator(new ProductImageValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public ProductImageDto ProductImage { get; set; }
        }

        public class Response : ResponseBase
        {
            public ProductImageDto ProductImage { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;

            public Handler(IHuntressDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var productImage = await _context.ProductImages.SingleAsync(x => x.ProductImageId == request.ProductImage.ProductImageId);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    ProductImage = productImage.ToDto()
                };
            }

        }
    }
}
