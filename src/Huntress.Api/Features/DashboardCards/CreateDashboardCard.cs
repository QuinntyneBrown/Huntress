using FluentValidation;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Huntress.Api.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Huntress.Api.Features
{
    public class CreateDashboardCard
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.DashboardCard).NotNull();
                RuleFor(request => request.DashboardCard).SetValidator(new DashboardCardValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public DashboardCardDto DashboardCard { get; set; }
        }

        public class Response : ResponseBase
        {
            public DashboardCardDto DashboardCard { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;

            public Handler(IHuntressDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var dashboardCard = new DashboardCard(request.DashboardCard.CardType, request.DashboardCard.Settings);

                _context.DashboardCards.Add(dashboardCard);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    DashboardCard = dashboardCard.ToDto()
                };
            }

        }
    }
}
