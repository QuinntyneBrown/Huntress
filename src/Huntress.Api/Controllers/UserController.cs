using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{userId}", Name = "GetUserByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetUserById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetUserById.Response>> GetById([FromRoute]GetUserById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.User == null)
            {
                return new NotFoundObjectResult(request.UserId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetUsersRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetUsers.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetUsers.Response>> Get()
            => await _mediator.Send(new GetUsers.Request());
        
        [HttpPost(Name = "CreateUserRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateUser.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateUser.Response>> Create([FromBody]CreateUser.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetUsersPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetUsersPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetUsersPage.Response>> Page([FromRoute]GetUsersPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateUserRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateUser.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateUser.Response>> Update([FromBody]UpdateUser.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{userId}", Name = "RemoveUserRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveUser.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveUser.Response>> Remove([FromRoute]RemoveUser.Request request)
            => await _mediator.Send(request);
        
    }
}
