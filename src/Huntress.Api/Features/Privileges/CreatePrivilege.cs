using FluentValidation;
using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;
using Huntress.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Huntress.Api.Features
{
    public class CreatePrivilege
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
                var privilege = new Privilege(
                    request.Privilege.RoleId,
                    request.Privilege.AccessRight,
                    request.Privilege.Aggregate
                    );

                _context.Privileges.Add(privilege);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Privilege = privilege.ToDto()
                };
            }

        }
    }
}
