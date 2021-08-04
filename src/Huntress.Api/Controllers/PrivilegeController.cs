using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrivilegeController
    {
        private readonly IMediator _mediator;

        public PrivilegeController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{privilegeId}", Name = "GetPrivilegeByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPrivilegeById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPrivilegeById.Response>> GetById([FromRoute] GetPrivilegeById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Privilege == null)
            {
                return new NotFoundObjectResult(request.PrivilegeId);
            }

            return response;
        }

        [HttpGet(Name = "GetPrivilegesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPrivileges.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPrivileges.Response>> Get()
            => await _mediator.Send(new GetPrivileges.Request());

        [HttpPost(Name = "CreatePrivilegeRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreatePrivilege.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreatePrivilege.Response>> Create([FromBody] CreatePrivilege.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetPrivilegesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPrivilegesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPrivilegesPage.Response>> Page([FromRoute] GetPrivilegesPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdatePrivilegeRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdatePrivilege.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdatePrivilege.Response>> Update([FromBody] UpdatePrivilege.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{privilegeId}", Name = "RemovePrivilegeRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemovePrivilege.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemovePrivilege.Response>> Remove([FromRoute] RemovePrivilege.Request request)
            => await _mediator.Send(request);

    }
}
