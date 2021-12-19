using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Models;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;

namespace Huntress.Api.Features
{
    public class CreateContent
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Content).NotNull();
                RuleFor(request => request.Content).SetValidator(new ContentValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public ContentDto Content { get; set; }
        }

        public class Response: ResponseBase
        {
            public ContentDto Content { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;
        
            public Handler(IHuntressDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var content = new Content();
                
                _context.Contents.Add(content);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Content = content.ToDto()
                };
            }
            
        }
    }
}
