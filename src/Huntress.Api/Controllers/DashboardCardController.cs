using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardCardController
    {
        private readonly IMediator _mediator;

        public DashboardCardController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{dashboardCardId}", Name = "GetDashboardCardByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDashboardCardById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDashboardCardById.Response>> GetById([FromRoute]GetDashboardCardById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.DashboardCard == null)
            {
                return new NotFoundObjectResult(request.DashboardCardId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetDashboardCardsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDashboardCards.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDashboardCards.Response>> Get()
            => await _mediator.Send(new GetDashboardCards.Request());
        
        [HttpPost(Name = "CreateDashboardCardRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateDashboardCard.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateDashboardCard.Response>> Create([FromBody]CreateDashboardCard.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetDashboardCardsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDashboardCardsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDashboardCardsPage.Response>> Page([FromRoute]GetDashboardCardsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateDashboardCardRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateDashboardCard.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateDashboardCard.Response>> Update([FromBody]UpdateDashboardCard.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{dashboardCardId}", Name = "RemoveDashboardCardRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveDashboardCard.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveDashboardCard.Response>> Remove([FromRoute]RemoveDashboardCard.Request request)
            => await _mediator.Send(request);
        
    }
}
