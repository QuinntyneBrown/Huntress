using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class UpdateProductCollection
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.ProductCollection).NotNull();
                RuleFor(request => request.ProductCollection).SetValidator(new ProductCollectionValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public ProductCollectionDto ProductCollection { get; set; }
        }

        public class Response : ResponseBase
        {
            public ProductCollectionDto ProductCollection { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;

            public Handler(IHuntressDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var productCollection = await _context.ProductCollections.SingleAsync(x => x.ProductCollectionId == request.ProductCollection.ProductCollectionId);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    ProductCollection = productCollection.ToDto()
                };
            }

        }
    }
}
