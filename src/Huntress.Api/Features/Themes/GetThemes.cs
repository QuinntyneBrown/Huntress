using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class GetThemes
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<ThemeDto> Themes { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;
        
            public Handler(IHuntressDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Themes = await _context.Themes.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
