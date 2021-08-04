using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Models;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;

namespace Huntress.Api.Features
{
    public class CreateCustomerCollection
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
                var customerCollection = new CustomerCollection(
                    request.CustomerCollection.CustomerCollectionType,
                    request.CustomerCollection.CustomerId);

                _context.CustomerCollections.Add(customerCollection);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    CustomerCollection = customerCollection.ToDto()
                };
            }

        }
    }
}
