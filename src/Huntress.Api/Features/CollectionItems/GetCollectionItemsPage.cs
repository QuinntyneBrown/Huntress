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
    public class GetCollectionItemsPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<CollectionItemDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;
        
            public Handler(IHuntressDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from collectionItem in _context.CollectionItems
                    select collectionItem;
                
                var length = await _context.CollectionItems.CountAsync();
                
                var collectionItems = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = collectionItems
                };
            }
            
        }
    }
}
