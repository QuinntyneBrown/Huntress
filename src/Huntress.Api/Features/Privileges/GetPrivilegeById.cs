using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class GetPrivilegeById
    {
        public class Request : IRequest<Response>
        {
            public Guid PrivilegeId { get; set; }
        }

        public class Response : ResponseBase
        {
            public PrivilegeDto Privilege { get; set; }
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
                    Privilege = (await _context.Privileges.SingleOrDefaultAsync(x => x.PrivilegeId == request.PrivilegeId)).ToDto()
                };
            }

        }
    }
}
