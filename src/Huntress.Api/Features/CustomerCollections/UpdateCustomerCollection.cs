using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class UpdateCustomerCollection
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.CustomerCollection).NotNull();
                RuleFor(request => request.CustomerCollection).SetValidator(new CustomerCollectionValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public CustomerCollectionDto CustomerCollection { get; set; }
        }

        public class Response : ResponseBase
        {
            public CustomerCollectionDto CustomerCollection { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;

            public Handler(IHuntressDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var customerCollection = await _context.CustomerCollections.SingleAsync(x => x.CustomerCollectionId == request.CustomerCollection.CustomerCollectionId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    CustomerCollection = customerCollection.ToDto()
                };
            }

        }
    }
}
