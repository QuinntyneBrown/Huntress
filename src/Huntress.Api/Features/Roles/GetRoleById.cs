using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class GetRoleById
    {
        public class Request : IRequest<Response>
        {
            public Guid RoleId { get; set; }
        }

        public class Response : ResponseBase
        {
            public RoleDto Role { get; set; }
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
                    Role = (await _context.Roles
                    .Include(x => x.Privileges)
                    .SingleOrDefaultAsync(x => x.RoleId == request.RoleId)).ToDto()
                };
            }

        }
    }
}
