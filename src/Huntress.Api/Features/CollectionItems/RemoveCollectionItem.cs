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
    public class RemoveCollectionItem
    {
        public class Request : IRequest<Response>
        {
            public Guid CollectionItemId { get; set; }
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
                var collectionItem = await _context.CollectionItems.SingleAsync(x => x.CollectionItemId == request.CollectionItemId);

                _context.CollectionItems.Remove(collectionItem);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    CollectionItem = collectionItem.ToDto()
                };
            }

        }
    }
}
