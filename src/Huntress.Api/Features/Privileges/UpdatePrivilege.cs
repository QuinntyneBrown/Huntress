using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class UpdatePrivilege
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Privilege).NotNull();
                RuleFor(request => request.Privilege).SetValidator(new PrivilegeValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public PrivilegeDto Privilege { get; set; }
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
                var privilege = await _context.Privileges.SingleAsync(x => x.PrivilegeId == request.Privilege.PrivilegeId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Privilege = privilege.ToDto()
                };
            }

        }
    }
}
