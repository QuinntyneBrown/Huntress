using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Huntress.Api.Features
{
    public class GetCustomerCollectionById
    {
        public class Request: IRequest<Response>
        {
            public Guid CustomerCollectionId { get; set; }
        }

        public class Response: ResponseBase
        {
            public CustomerCollectionDto CustomerCollection { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;
        
            public Handler(IHuntressDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    CustomerCollection = (await _context.CustomerCollections.SingleOrDefaultAsync(x => x.CustomerCollectionId == request.CustomerCollectionId)).ToDto()
                };
            }
            
        }
    }
}
