using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageContentController
    {
        private readonly IMediator _mediator;

        public ImageContentController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{imageContentId}", Name = "GetImageContentByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetImageContentById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetImageContentById.Response>> GetById([FromRoute] GetImageContentById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.ImageContent == null)
            {
                return new NotFoundObjectResult(request.ImageContentId);
            }

            return response;
        }

        [HttpGet(Name = "GetImageContentsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetImageContents.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetImageContents.Response>> Get()
            => await _mediator.Send(new GetImageContents.Request());

        [HttpGet("type/{imageContentType}", Name = "GetImageContentsByTypeRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetImageContentsByType.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetImageContentsByType.Response>> GetByType([FromRoute] GetImageContentsByType.Request requet)
            => await _mediator.Send(requet);

        [HttpGet("type/{imageContentType}/single", Name = "GetImageContentByTypeRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetImageContentByType.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetImageContentByType.Response>> GetSingleByType([FromRoute] GetImageContentByType.Request requet)
    => await _mediator.Send(requet);

        [HttpPost(Name = "CreateImageContentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateImageContent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateImageContent.Response>> Create([FromBody] CreateImageContent.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetImageContentsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetImageContentsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetImageContentsPage.Response>> Page([FromRoute] GetImageContentsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateImageContentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateImageContent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateImageContent.Response>> Update([FromBody] UpdateImageContent.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{imageContentId}", Name = "RemoveImageContentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveImageContent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveImageContent.Response>> Remove([FromRoute] RemoveImageContent.Request request)
            => await _mediator.Send(request);

    }
}
