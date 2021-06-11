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
    public class RemoveImageContent
    {
        public class Request : IRequest<Response>
        {
            public Guid ImageContentId { get; set; }
        }

        public class Response : ResponseBase
        {
            public ImageContentDto ImageContent { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;

            public Handler(IHuntressDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var imageContent = await _context.ImageContents.SingleAsync(x => x.ImageContentId == request.ImageContentId);

                _context.ImageContents.Remove(imageContent);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    ImageContent = imageContent.ToDto()
                };
            }

        }
    }
}
