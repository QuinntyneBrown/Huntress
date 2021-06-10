using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerCollectionController
    {
        private readonly IMediator _mediator;

        public CustomerCollectionController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{customerCollectionId}", Name = "GetCustomerCollectionByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCustomerCollectionById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCustomerCollectionById.Response>> GetById([FromRoute]GetCustomerCollectionById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.CustomerCollection == null)
            {
                return new NotFoundObjectResult(request.CustomerCollectionId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetCustomerCollectionsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCustomerCollections.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCustomerCollections.Response>> Get()
            => await _mediator.Send(new GetCustomerCollections.Request());
        
        [HttpPost(Name = "CreateCustomerCollectionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateCustomerCollection.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateCustomerCollection.Response>> Create([FromBody]CreateCustomerCollection.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetCustomerCollectionsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCustomerCollectionsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCustomerCollectionsPage.Response>> Page([FromRoute]GetCustomerCollectionsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateCustomerCollectionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateCustomerCollection.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateCustomerCollection.Response>> Update([FromBody]UpdateCustomerCollection.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{customerCollectionId}", Name = "RemoveCustomerCollectionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveCustomerCollection.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveCustomerCollection.Response>> Remove([FromRoute]RemoveCustomerCollection.Request request)
            => await _mediator.Send(request);
        
    }
}
