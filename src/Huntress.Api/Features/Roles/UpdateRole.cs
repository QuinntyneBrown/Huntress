using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class UpdateRole
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Role).NotNull();
                RuleFor(request => request.Role).SetValidator(new RoleValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public RoleDto Role { get; set; }
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
                var role = await _context.Roles.SingleAsync(x => x.RoleId == request.Role.RoleId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Role = role.ToDto()
                };
            }

        }
    }
}
