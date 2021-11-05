using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class UpdateTheme
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Theme).NotNull();
                RuleFor(request => request.Theme).SetValidator(new ThemeValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public ThemeDto Theme { get; set; }
        }

        public class Response: ResponseBase
        {
            public ThemeDto Theme { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;
        
            public Handler(IHuntressDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var theme = await _context.Themes.SingleAsync(x => x.ThemeId == request.Theme.ThemeId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Theme = theme.ToDto()
                };
            }
            
        }
    }
}
