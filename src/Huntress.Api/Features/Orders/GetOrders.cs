using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Huntress.Api.Features
{
    public class GetOrders
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public List<OrderDto> Orders { get; set; }
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
                    Orders = await _context.Orders.Select(x => x.ToDto()).ToListAsync()
                };
            }

        }
    }
}
