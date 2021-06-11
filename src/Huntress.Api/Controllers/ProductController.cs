using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{productId}", Name = "GetProductByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProductById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProductById.Response>> GetById([FromRoute] GetProductById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Product == null)
            {
                return new NotFoundObjectResult(request.ProductId);
            }

            return response;
        }

        [HttpGet(Name = "GetProductsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProducts.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProducts.Response>> Get()
            => await _mediator.Send(new GetProducts.Request());

        [HttpPost(Name = "CreateProductRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateProduct.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateProduct.Response>> Create([FromBody] CreateProduct.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetProductsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProductsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProductsPage.Response>> Page([FromRoute] GetProductsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateProductRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateProduct.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateProduct.Response>> Update([FromBody] UpdateProduct.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{productId}", Name = "RemoveProductRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveProduct.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveProduct.Response>> Remove([FromRoute] RemoveProduct.Request request)
            => await _mediator.Send(request);

    }
}
