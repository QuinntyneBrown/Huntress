using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImageController
    {
        private readonly IMediator _mediator;

        public ProductImageController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{productImageId}", Name = "GetProductImageByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProductImageById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProductImageById.Response>> GetById([FromRoute] GetProductImageById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.ProductImage == null)
            {
                return new NotFoundObjectResult(request.ProductImageId);
            }

            return response;
        }

        [HttpGet(Name = "GetProductImagesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProductImages.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProductImages.Response>> Get()
            => await _mediator.Send(new GetProductImages.Request());

        [HttpPost(Name = "CreateProductImageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateProductImage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateProductImage.Response>> Create([FromBody] CreateProductImage.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetProductImagesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProductImagesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProductImagesPage.Response>> Page([FromRoute] GetProductImagesPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateProductImageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateProductImage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateProductImage.Response>> Update([FromBody] UpdateProductImage.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{productImageId}", Name = "RemoveProductImageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveProductImage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveProductImage.Response>> Remove([FromRoute] RemoveProductImage.Request request)
            => await _mediator.Send(request);

    }
}
