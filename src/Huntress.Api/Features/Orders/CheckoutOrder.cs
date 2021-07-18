using FluentValidation;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using IStripeClient = Huntress.Api.Services.IStripeClient;

namespace Huntress.Api.Features
{
    public class CheckoutOrder
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.OrderId).NotEqual(default(System.Guid));
                RuleFor(x => x.Number).NotNull().NotEmpty();
                RuleFor(x => x.ExpMonth).NotEqual(default(long));
                RuleFor(x => x.ExpYear).NotEqual(default(long));
                RuleFor(x => x.Cvc).NotNull().NotEmpty();
            }
        }

        public class Request : IRequest<Response>
        {
            public System.Guid OrderId { get; set; }
            public string Number { get; set; }
            public long ExpMonth { get; set; }
            public long ExpYear { get; set; }
            public string Cvc { get; set; }
        }

        public class Response : ResponseBase
        {
            public OrderDto Order { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;
            private readonly IStripeClient _stripeClient;
            public Handler(IHuntressDbContext context, IStripeClient stripeClient)
            {
                _context = context;
                _stripeClient = stripeClient;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var order = await _context.Orders.Include(x => x.OrderItems).SingleAsync(x => x.OrderId == request.OrderId);

                order.SetProcessingPaymentStatus();

                await _context.SaveChangesAsync(cancellationToken);

                var charge = await _stripeClient.Charge(
                    Convert.ToInt64(order.Cost),
                    request.Number,
                    request.ExpYear,
                    request.ExpMonth,
                    request.Cvc,
                    "Order",
                    cancellationToken);

                if (charge.Paid)
                {
                    order.SetPaidStatus();
                    await _context.SaveChangesAsync(cancellationToken);
                    return new();
                }

                throw new Exception();

            }
        }
    }
}
