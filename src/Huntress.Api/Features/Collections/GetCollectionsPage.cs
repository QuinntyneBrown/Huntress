using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Huntress.Api.Extensions;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Huntress.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class GetCollectionsPage
    {
        public class Request : IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response : ResponseBase
        {
            public int Length { get; set; }
            public List<CollectionDto> Entities { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;

            public Handler(IHuntressDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from collection in _context.Collections
                            select collection;

                var length = await _context.Collections.CountAsync();

                var collections = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();

                return new()
                {
                    Length = length,
                    Entities = collections
                };
            }

        }
    }
}
