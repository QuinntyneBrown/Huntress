using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Huntress.Domain.Interfaces;

namespace Huntress.Api.Features
{
    public class GetCollectionItemById
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
                return new()
                {
                    CollectionItem = (await _context.CollectionItems.SingleOrDefaultAsync(x => x.CollectionItemId == request.CollectionItemId)).ToDto()
                };
            }

        }
    }
}
