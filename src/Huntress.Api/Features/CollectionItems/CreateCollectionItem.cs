using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Domain.Entities;
using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;

namespace Huntress.Api.Features
{
    public class CreateCollectionItem
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.CollectionItem).NotNull();
                RuleFor(request => request.CollectionItem).SetValidator(new CollectionItemValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public CollectionItemDto CollectionItem { get; set; }
        }

        public class Response : ResponseBase
        {
            public CollectionItemDto CollectionItem { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;

            public Handler(IHuntressDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var collectionItem = new CollectionItem(request.CollectionItem.CollectionId, request.CollectionItem.ProductId);

                _context.CollectionItems.Add(collectionItem);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    CollectionItem = collectionItem.ToDto()
                };
            }

        }
    }
}
