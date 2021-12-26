using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConnectorController
    {
        private readonly IMediator _mediator;

        public ConnectorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult<UploadDigitalAsset.Response>> Post([FromQuery] string command)
        {
            return await _mediator.Send(new UploadDigitalAsset.Request());
        }
    }
}
