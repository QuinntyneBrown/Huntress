using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class UpdateJsonContent
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.JsonContent).NotNull();
                RuleFor(request => request.JsonContent).SetValidator(new JsonContentValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public JsonContentDto JsonContent { get; set; }
        }

        public class Response: ResponseBase
        {
            public JsonContentDto JsonContent { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;
        
            public Handler(IHuntressDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var jsonContent = await _context.JsonContents.SingleAsync(x => x.JsonContentId == request.JsonContent.JsonContentId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    JsonContent = jsonContent.ToDto()
                };
            }
            
        }
    }
}
