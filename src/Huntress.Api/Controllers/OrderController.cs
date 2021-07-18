using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost("checkout", Name = "CheckoutOrderRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CheckoutOrder.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CheckoutOrder.Response>> Create([FromBody] CheckoutOrder.Request request)
            => await _mediator.Send(request);

        [HttpGet("{orderId}", Name = "GetOrderByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOrderById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOrderById.Response>> GetById([FromRoute]GetOrderById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Order == null)
            {
                return new NotFoundObjectResult(request.OrderId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetOrdersRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOrders.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOrders.Response>> Get()
            => await _mediator.Send(new GetOrders.Request());
        
        [HttpPost(Name = "CreateOrderRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateOrder.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateOrder.Response>> Create([FromBody]CreateOrder.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetOrdersPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOrdersPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOrdersPage.Response>> Page([FromRoute]GetOrdersPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateOrderRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateOrder.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateOrder.Response>> Update([FromBody]UpdateOrder.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{orderId}", Name = "RemoveOrderRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveOrder.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveOrder.Response>> Remove([FromRoute]RemoveOrder.Request request)
            => await _mediator.Send(request);
        
    }
}
