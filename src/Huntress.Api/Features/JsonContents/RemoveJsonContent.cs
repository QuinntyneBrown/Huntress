using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Huntress.Api.Models;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;

namespace Huntress.Api.Features
{
    public class RemoveJsonContent
    {
        public class Request: IRequest<Response>
        {
            public Guid JsonContentId { get; set; }
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
                var jsonContent = await _context.JsonContents.SingleAsync(x => x.JsonContentId == request.JsonContentId);
                
                _context.JsonContents.Remove(jsonContent);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    JsonContent = jsonContent.ToDto()
                };
            }
            
        }
    }
}
