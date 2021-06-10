using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Huntress.Api.Models;
using Huntress.Api.Core;
using Huntress.Api.Interfaces;

namespace Huntress.Api.Features
{
    public class RemoveCustomerCollection
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
                var customerCollection = await _context.CustomerCollections.SingleAsync(x => x.CustomerCollectionId == request.CustomerCollectionId);
                
                _context.CustomerCollections.Remove(customerCollection);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    CustomerCollection = customerCollection.ToDto()
                };
            }
            
        }
    }
}
