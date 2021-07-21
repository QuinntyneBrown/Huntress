using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController
    {
        private readonly IMediator _mediator;

        public OrderItemController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{orderItemId}", Name = "GetOrderItemByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOrderItemById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOrderItemById.Response>> GetById([FromRoute] GetOrderItemById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.OrderItem == null)
            {
                return new NotFoundObjectResult(request.OrderItemId);
            }

            return response;
        }

        [HttpGet(Name = "GetOrderItemsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOrderItems.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOrderItems.Response>> Get()
            => await _mediator.Send(new GetOrderItems.Request());

        [HttpPost(Name = "CreateOrderItemRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateOrderItem.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateOrderItem.Response>> Create([FromBody] CreateOrderItem.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetOrderItemsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOrderItemsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOrderItemsPage.Response>> Page([FromRoute] GetOrderItemsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateOrderItemRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateOrderItem.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateOrderItem.Response>> Update([FromBody] UpdateOrderItem.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{orderItemId}", Name = "RemoveOrderItemRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveOrderItem.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveOrderItem.Response>> Remove([FromRoute] RemoveOrderItem.Request request)
            => await _mediator.Send(request);

    }
}
