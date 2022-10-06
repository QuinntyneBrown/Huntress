using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Huntress.Domain.Entities;
using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;

namespace Huntress.Api.Features
{
    public class RemoveProductCollection
    {
        public class Request : IRequest<Response>
        {
            public Guid ProductCollectionId { get; set; }
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
                var productCollection = await _context.ProductCollections.SingleAsync(x => x.ProductCollectionId == request.ProductCollectionId);

                _context.ProductCollections.Remove(productCollection);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    ProductCollection = productCollection.ToDto()
                };
            }

        }
    }
}
