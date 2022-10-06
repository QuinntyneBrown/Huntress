using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Huntress.Domain.Entities;
using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;

namespace Huntress.Api.Features
{
    public class RemovePrivilege
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
                var privilege = await _context.Privileges.SingleAsync(x => x.PrivilegeId == request.PrivilegeId);

                _context.Privileges.Remove(privilege);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Privilege = privilege.ToDto()
                };
            }

        }
    }
}
