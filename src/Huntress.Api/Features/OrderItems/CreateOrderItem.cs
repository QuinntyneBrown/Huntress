using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Models;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;

namespace Huntress.Api.Features
{
    public class CreateOrderItem
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.OrderItem).NotNull();
                RuleFor(request => request.OrderItem).SetValidator(new OrderItemValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public OrderItemDto OrderItem { get; set; }
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
                var orderItem = new OrderItem();
                
                _context.OrderItems.Add(orderItem);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    OrderItem = orderItem.ToDto()
                };
            }
            
        }
    }
}
