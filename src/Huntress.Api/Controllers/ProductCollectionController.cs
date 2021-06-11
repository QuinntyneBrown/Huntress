using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCollectionController
    {
        private readonly IMediator _mediator;

        public ProductCollectionController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{productCollectionId}", Name = "GetProductCollectionByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProductCollectionById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProductCollectionById.Response>> GetById([FromRoute] GetProductCollectionById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.ProductCollection == null)
            {
                return new NotFoundObjectResult(request.ProductCollectionId);
            }

            return response;
        }

        [HttpGet(Name = "GetProductCollectionsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProductCollections.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProductCollections.Response>> Get()
            => await _mediator.Send(new GetProductCollections.Request());

        [HttpPost(Name = "CreateProductCollectionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateProductCollection.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateProductCollection.Response>> Create([FromBody] CreateProductCollection.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetProductCollectionsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProductCollectionsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProductCollectionsPage.Response>> Page([FromRoute] GetProductCollectionsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateProductCollectionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateProductCollection.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateProductCollection.Response>> Update([FromBody] UpdateProductCollection.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{productCollectionId}", Name = "RemoveProductCollectionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveProductCollection.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveProductCollection.Response>> Remove([FromRoute] RemoveProductCollection.Request request)
            => await _mediator.Send(request);

    }
}
