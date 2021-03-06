using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Huntress.Api.Features
{
    public class RemoveOrder
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
                var order = await _context.Orders.SingleAsync(x => x.OrderId == request.OrderId);

                _context.Orders.Remove(order);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Order = order.ToDto()
                };
            }

        }
    }
}
