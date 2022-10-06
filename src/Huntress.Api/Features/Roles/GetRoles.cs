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
    public class GetRoles
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public List<RoleDto> Roles { get; set; }
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
                    Roles = await _context.Roles
                    .Include(x => x.Privileges)
                    .Select(x => x.ToDto()).ToListAsync()
                };
            }

        }
    }
}
