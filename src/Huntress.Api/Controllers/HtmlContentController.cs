using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HtmlContentController
    {
        private readonly IMediator _mediator;

        public HtmlContentController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{htmlContentId}", Name = "GetHtmlContentByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetHtmlContentById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetHtmlContentById.Response>> GetById([FromRoute] GetHtmlContentById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.HtmlContent == null)
            {
                return new NotFoundObjectResult(request.HtmlContentId);
            }

            return response;
        }

        [HttpGet("type/{htmlContentType}", Name = "GetHtmlContentByTypeRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetHtmlContentByType.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetHtmlContentByType.Response>> GetByType([FromRoute] GetHtmlContentByType.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.HtmlContent == null)
            {
                return new NotFoundObjectResult(request.HtmlContentType);
            }

            return response;
        }

        [HttpGet(Name = "GetHtmlContentsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetHtmlContents.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetHtmlContents.Response>> Get()
            => await _mediator.Send(new GetHtmlContents.Request());

        [HttpPost(Name = "CreateHtmlContentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateHtmlContent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateHtmlContent.Response>> Create([FromBody] CreateHtmlContent.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetHtmlContentsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetHtmlContentsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetHtmlContentsPage.Response>> Page([FromRoute] GetHtmlContentsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateHtmlContentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateHtmlContent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateHtmlContent.Response>> Update([FromBody] UpdateHtmlContent.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{htmlContentId}", Name = "RemoveHtmlContentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveHtmlContent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveHtmlContent.Response>> Remove([FromRoute] RemoveHtmlContent.Request request)
            => await _mediator.Send(request);

    }
}
