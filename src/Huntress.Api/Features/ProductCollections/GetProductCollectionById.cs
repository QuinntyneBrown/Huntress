using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class GetProductCollectionById
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
                return new()
                {
                    ProductCollection = (await _context.ProductCollections.SingleOrDefaultAsync(x => x.ProductCollectionId == request.ProductCollectionId)).ToDto()
                };
            }

        }
    }
}
