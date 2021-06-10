using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionItemController
    {
        private readonly IMediator _mediator;

        public CollectionItemController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{collectionItemId}", Name = "GetCollectionItemByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCollectionItemById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCollectionItemById.Response>> GetById([FromRoute]GetCollectionItemById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.CollectionItem == null)
            {
                return new NotFoundObjectResult(request.CollectionItemId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetCollectionItemsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCollectionItems.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCollectionItems.Response>> Get()
            => await _mediator.Send(new GetCollectionItems.Request());
        
        [HttpPost(Name = "CreateCollectionItemRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateCollectionItem.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateCollectionItem.Response>> Create([FromBody]CreateCollectionItem.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetCollectionItemsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCollectionItemsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCollectionItemsPage.Response>> Page([FromRoute]GetCollectionItemsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateCollectionItemRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateCollectionItem.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateCollectionItem.Response>> Update([FromBody]UpdateCollectionItem.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{collectionItemId}", Name = "RemoveCollectionItemRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveCollectionItem.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveCollectionItem.Response>> Remove([FromRoute]RemoveCollectionItem.Request request)
            => await _mediator.Send(request);
        
    }
}
