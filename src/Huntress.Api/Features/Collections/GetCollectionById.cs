using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class GetCollectionById
    {
        public class Request : IRequest<Response>
        {
            public Guid CollectionId { get; set; }
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
                return new()
                {
                    Collection = (await _context.Collections.SingleOrDefaultAsync(x => x.CollectionId == request.CollectionId)).ToDto()
                };
            }

        }
    }
}
