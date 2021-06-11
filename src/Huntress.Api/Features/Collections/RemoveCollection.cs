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
    public class RemoveCollection
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
                var collection = await _context.Collections.SingleAsync(x => x.CollectionId == request.CollectionId);

                _context.Collections.Remove(collection);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Collection = collection.ToDto()
                };
            }

        }
    }
}
