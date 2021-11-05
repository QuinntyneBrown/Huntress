using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class GetJsonContents
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<JsonContentDto> JsonContents { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;
        
            public Handler(IHuntressDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    JsonContents = await _context.JsonContents.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
