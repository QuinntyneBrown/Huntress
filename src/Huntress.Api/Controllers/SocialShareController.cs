using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocialShareController
    {
        private readonly IMediator _mediator;

        public SocialShareController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{socialShareId}", Name = "GetSocialShareByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSocialShareById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSocialShareById.Response>> GetById([FromRoute] GetSocialShareById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.SocialShare == null)
            {
                return new NotFoundObjectResult(request.SocialShareId);
            }

            return response;
        }

        [HttpGet(Name = "GetSocialSharesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSocialShares.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSocialShares.Response>> Get()
            => await _mediator.Send(new GetSocialShares.Request());

        [HttpPost(Name = "CreateSocialShareRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateSocialShare.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateSocialShare.Response>> Create([FromBody] CreateSocialShare.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetSocialSharesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSocialSharesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSocialSharesPage.Response>> Page([FromRoute] GetSocialSharesPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateSocialShareRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateSocialShare.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateSocialShare.Response>> Update([FromBody] UpdateSocialShare.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{socialShareId}", Name = "RemoveSocialShareRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveSocialShare.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveSocialShare.Response>> Remove([FromRoute] RemoveSocialShare.Request request)
            => await _mediator.Send(request);

    }
}
