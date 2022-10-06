using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class UpdateStoredEvent
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.StoredEvent).NotNull();
                RuleFor(request => request.StoredEvent).SetValidator(new StoredEventValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public StoredEventDto StoredEvent { get; set; }
        }

        public class Response: ResponseBase
        {
            public StoredEventDto StoredEvent { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;
        
            public Handler(IHuntressDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var storedEvent = await _context.StoredEvents.SingleAsync(x => x.StoredEventId == request.StoredEvent.StoredEventId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    StoredEvent = storedEvent.ToDto()
                };
            }
            
        }
    }
}
