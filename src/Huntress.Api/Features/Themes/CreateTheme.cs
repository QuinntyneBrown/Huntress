using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Models;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;

namespace Huntress.Api.Features
{
    public class CreateTheme
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
                var theme = new Theme();
                
                _context.Themes.Add(theme);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Theme = theme.ToDto()
                };
            }
            
        }
    }
}
