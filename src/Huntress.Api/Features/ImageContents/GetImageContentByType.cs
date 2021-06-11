using Huntress.Api.Interfaces;
using Huntress.Api.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Huntress.Api.Features
{
    public class GetImageContentByType
    {
        public class Request : IRequest<Response> {
            public ImageContentType ImageContentType { get; set; }
        }

        public class Response
        {
            public ImageContentDto ImageContent { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHuntressDbContext _context;

            public Handler(IHuntressDbContext context){
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
			    return new () { 
                    ImageContent = _context.ImageContents
                    .SingleOrDefault(x => x.ImageContentType == request.ImageContentType)
                    .ToDto()
                };
            }
        }
    }
}
