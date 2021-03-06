using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Huntress.Api.Features
{
    public class GetOrderById
    {
        public class Request : IRequest<Response>
        {
            public Guid OrderId { get; set; }
        }

        public class Response : ResponseBase
        {
            public OrderDto Order { get; set; }
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
                    Order = (await _context.Orders.SingleOrDefaultAsync(x => x.OrderId == request.OrderId)).ToDto()
                };
            }

        }
    }
}
