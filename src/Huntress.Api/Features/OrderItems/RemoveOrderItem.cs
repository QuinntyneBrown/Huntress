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
    public class RemoveOrderItem
    {
        public class Request: IRequest<Response>
        {
            public Guid OrderItemId { get; set; }
        }

        public class Response: ResponseBase
        {
            public OrderItemDto OrderItem { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;
        
            public Handler(IHuntressDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var orderItem = await _context.OrderItems.SingleAsync(x => x.OrderItemId == request.OrderItemId);
                
                _context.OrderItems.Remove(orderItem);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    OrderItem = orderItem.ToDto()
                };
            }
            
        }
    }
}
