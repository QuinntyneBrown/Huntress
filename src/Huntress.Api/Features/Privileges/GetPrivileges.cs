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
    public class GetPrivileges
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public List<PrivilegeDto> Privileges { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;

            public Handler(IHuntressDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new()
                {
                    Privileges = await _context.Privileges.Select(x => x.ToDto()).ToListAsync()
                };
            }

        }
    }
}
