using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionController
    {
        private readonly IMediator _mediator;

        public CollectionController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{collectionId}", Name = "GetCollectionByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCollectionById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCollectionById.Response>> GetById([FromRoute]GetCollectionById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Collection == null)
            {
                return new NotFoundObjectResult(request.CollectionId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetCollectionsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCollections.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCollections.Response>> Get()
            => await _mediator.Send(new GetCollections.Request());
        
        [HttpPost(Name = "CreateCollectionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateCollection.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateCollection.Response>> Create([FromBody]CreateCollection.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetCollectionsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCollectionsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCollectionsPage.Response>> Page([FromRoute]GetCollectionsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateCollectionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateCollection.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateCollection.Response>> Update([FromBody]UpdateCollection.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{collectionId}", Name = "RemoveCollectionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveCollection.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveCollection.Response>> Remove([FromRoute]RemoveCollection.Request request)
            => await _mediator.Send(request);
        
    }
}
