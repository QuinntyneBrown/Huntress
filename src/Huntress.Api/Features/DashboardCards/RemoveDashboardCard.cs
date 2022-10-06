using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Huntress.Domain.Entities;
using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;

namespace Huntress.Api.Features
{
    public class RemoveDashboardCard
    {
        public class Request: IRequest<Response>
        {
            public Guid DashboardCardId { get; set; }
        }

        public class Response: ResponseBase
        {
            public DashboardCardDto DashboardCard { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;
        
            public Handler(IHuntressDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var dashboardCard = await _context.DashboardCards.SingleAsync(x => x.DashboardCardId == request.DashboardCardId);
                
                _context.DashboardCards.Remove(dashboardCard);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    DashboardCard = dashboardCard.ToDto()
                };
            }
            
        }
    }
}
