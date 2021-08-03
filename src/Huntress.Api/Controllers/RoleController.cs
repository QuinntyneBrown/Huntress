using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{roleId}", Name = "GetRoleByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetRoleById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetRoleById.Response>> GetById([FromRoute]GetRoleById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Role == null)
            {
                return new NotFoundObjectResult(request.RoleId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetRolesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetRoles.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetRoles.Response>> Get()
            => await _mediator.Send(new GetRoles.Request());
        
        [HttpPost(Name = "CreateRoleRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateRole.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateRole.Response>> Create([FromBody]CreateRole.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetRolesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetRolesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetRolesPage.Response>> Page([FromRoute]GetRolesPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateRoleRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateRole.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateRole.Response>> Update([FromBody]UpdateRole.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{roleId}", Name = "RemoveRoleRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveRole.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveRole.Response>> Remove([FromRoute]RemoveRole.Request request)
            => await _mediator.Send(request);
        
    }
}
