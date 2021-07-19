using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductUpdateRequestController
    {
        private readonly IMediator _mediator;

        public ProductUpdateRequestController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{productUpdateRequestId}", Name = "GetProductUpdateRequestByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProductUpdateRequestById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProductUpdateRequestById.Response>> GetById([FromRoute]GetProductUpdateRequestById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.ProductUpdateRequest == null)
            {
                return new NotFoundObjectResult(request.ProductUpdateRequestId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetProductUpdateRequestsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProductUpdateRequests.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProductUpdateRequests.Response>> Get()
            => await _mediator.Send(new GetProductUpdateRequests.Request());
        
        [HttpPost(Name = "CreateProductUpdateRequestRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateProductUpdateRequest.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateProductUpdateRequest.Response>> Create([FromBody]CreateProductUpdateRequest.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetProductUpdateRequestsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProductUpdateRequestsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProductUpdateRequestsPage.Response>> Page([FromRoute]GetProductUpdateRequestsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateProductUpdateRequestRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateProductUpdateRequest.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateProductUpdateRequest.Response>> Update([FromBody]UpdateProductUpdateRequest.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{productUpdateRequestId}", Name = "RemoveProductUpdateRequestRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveProductUpdateRequest.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveProductUpdateRequest.Response>> Remove([FromRoute]RemoveProductUpdateRequest.Request request)
            => await _mediator.Send(request);
        
    }
}
