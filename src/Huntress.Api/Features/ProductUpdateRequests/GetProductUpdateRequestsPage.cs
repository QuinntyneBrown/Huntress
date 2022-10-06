using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Huntress.Api.Extensions;
using Huntress.Domain.Common;
using Huntress.Domain.Interfaces;
using Huntress.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class GetProductUpdateRequestsPage
    {
        public class Request : IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response : ResponseBase
        {
            public int Length { get; set; }
            public List<ProductUpdateRequestDto> Entities { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;

            public Handler(IHuntressDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from productUpdateRequest in _context.ProductUpdateRequests
                            select productUpdateRequest;

                var length = await _context.ProductUpdateRequests.CountAsync();

                var productUpdateRequests = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();

                return new()
                {
                    Length = length,
                    Entities = productUpdateRequests
                };
            }

        }
    }
}
