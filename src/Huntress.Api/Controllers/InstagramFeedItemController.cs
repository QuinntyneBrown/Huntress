using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstagramFeedItemController
    {
        private readonly IMediator _mediator;

        public InstagramFeedItemController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{instagramFeedItemId}", Name = "GetInstagramFeedItemByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetInstagramFeedItemById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetInstagramFeedItemById.Response>> GetById([FromRoute] GetInstagramFeedItemById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.InstagramFeedItem == null)
            {
                return new NotFoundObjectResult(request.InstagramFeedItemId);
            }

            return response;
        }

        [HttpGet(Name = "GetInstagramFeedItemsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetInstagramFeedItems.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetInstagramFeedItems.Response>> Get()
            => await _mediator.Send(new GetInstagramFeedItems.Request());

        [HttpPost(Name = "CreateInstagramFeedItemRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateInstagramFeedItem.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateInstagramFeedItem.Response>> Create([FromBody] CreateInstagramFeedItem.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetInstagramFeedItemsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetInstagramFeedItemsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetInstagramFeedItemsPage.Response>> Page([FromRoute] GetInstagramFeedItemsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateInstagramFeedItemRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateInstagramFeedItem.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateInstagramFeedItem.Response>> Update([FromBody] UpdateInstagramFeedItem.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{instagramFeedItemId}", Name = "RemoveInstagramFeedItemRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveInstagramFeedItem.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveInstagramFeedItem.Response>> Remove([FromRoute] RemoveInstagramFeedItem.Request request)
            => await _mediator.Send(request);

    }
}
