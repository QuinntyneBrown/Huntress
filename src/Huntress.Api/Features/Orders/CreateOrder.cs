using FluentValidation;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Huntress.Api.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Huntress.Api.Features
{
    public class CreateOrder
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Order).NotNull();
                RuleFor(request => request.Order).SetValidator(new OrderValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public OrderDto Order { get; set; }
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
                var order = new Order(
                    request.Order.CustomerId,
                    request.Order.Cost,
                    request.Order.Status,
                    request.Order.OrderDate,
                    request.Order.ShippingAddress,
                    request.Order.BillingAddress
                    );

                _context.Orders.Add(order);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Order = order.ToDto()
                };
            }

        }
    }
}
