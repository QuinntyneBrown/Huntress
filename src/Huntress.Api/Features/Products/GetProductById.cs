using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class GetProductById
    {
        public class Request : IRequest<Response>
        {
            public Guid ProductId { get; set; }
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
                return new()
                {
                    Product = (await _context.Products
                    .Include(x => x.ProductImages)
                    .SingleOrDefaultAsync(x => x.ProductId == request.ProductId)).ToDto()
                };
            }

        }
    }
}
