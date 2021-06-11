using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstagramFeedController
    {
        private readonly IMediator _mediator;

        public InstagramFeedController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{instagramFeedId}", Name = "GetInstagramFeedByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetInstagramFeedById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetInstagramFeedById.Response>> GetById([FromRoute] GetInstagramFeedById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.InstagramFeed == null)
            {
                return new NotFoundObjectResult(request.InstagramFeedId);
            }

            return response;
        }

        [HttpGet(Name = "GetInstagramFeedsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetInstagramFeeds.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetInstagramFeeds.Response>> Get()
            => await _mediator.Send(new GetInstagramFeeds.Request());

        [HttpPost(Name = "CreateInstagramFeedRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateInstagramFeed.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateInstagramFeed.Response>> Create([FromBody] CreateInstagramFeed.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetInstagramFeedsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetInstagramFeedsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetInstagramFeedsPage.Response>> Page([FromRoute] GetInstagramFeedsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateInstagramFeedRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateInstagramFeed.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateInstagramFeed.Response>> Update([FromBody] UpdateInstagramFeed.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{instagramFeedId}", Name = "RemoveInstagramFeedRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveInstagramFeed.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveInstagramFeed.Response>> Remove([FromRoute] RemoveInstagramFeed.Request request)
            => await _mediator.Send(request);

    }
}
