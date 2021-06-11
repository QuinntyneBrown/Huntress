using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Huntress.Api.Models;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;

namespace Huntress.Api.Features
{
    public class RemoveProductImage
    {
        public class Request : IRequest<Response>
        {
            public Guid ProductImageId { get; set; }
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
                var productImage = await _context.ProductImages.SingleAsync(x => x.ProductImageId == request.ProductImageId);

                _context.ProductImages.Remove(productImage);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    ProductImage = productImage.ToDto()
                };
            }

        }
    }
}
