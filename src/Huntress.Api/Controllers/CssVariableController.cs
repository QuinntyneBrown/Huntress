using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CssVariableController
    {
        private readonly IMediator _mediator;

        public CssVariableController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{cssVariableId}", Name = "GetCssVariableByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCssVariableById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCssVariableById.Response>> GetById([FromRoute] GetCssVariableById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.CssVariable == null)
            {
                return new NotFoundObjectResult(request.CssVariableId);
            }

            return response;
        }

        [HttpGet(Name = "GetCssVariablesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCssVariables.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCssVariables.Response>> Get()
            => await _mediator.Send(new GetCssVariables.Request());

        [HttpPost(Name = "CreateCssVariableRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateCssVariable.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateCssVariable.Response>> Create([FromBody] CreateCssVariable.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetCssVariablesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCssVariablesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCssVariablesPage.Response>> Page([FromRoute] GetCssVariablesPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateCssVariableRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateCssVariable.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateCssVariable.Response>> Update([FromBody] UpdateCssVariable.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{cssVariableId}", Name = "RemoveCssVariableRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveCssVariable.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveCssVariable.Response>> Remove([FromRoute] RemoveCssVariable.Request request)
            => await _mediator.Send(request);

    }
}
