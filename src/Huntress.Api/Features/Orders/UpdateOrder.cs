using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class UpdateOrder
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Order).NotNull();
                RuleFor(request => request.Order).SetValidator(new OrderValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public OrderDto Order { get; set; }
        }

        public class Response: ResponseBase
        {
            public OrderDto Order { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;
        
            public Handler(IHuntressDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var order = await _context.Orders.SingleAsync(x => x.OrderId == request.Order.OrderId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Order = order.ToDto()
                };
            }
            
        }
    }
}
