using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class UpdateCollection
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Collection).NotNull();
                RuleFor(request => request.Collection).SetValidator(new CollectionValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public CollectionDto Collection { get; set; }
        }

        public class Response : ResponseBase
        {
            public CollectionDto Collection { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;

            public Handler(IHuntressDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var collection = await _context.Collections.SingleAsync(x => x.CollectionId == request.Collection.CollectionId);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Collection = collection.ToDto()
                };
            }

        }
    }
}
