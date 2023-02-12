// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContentService.Core.AggregateModel.ContentAggregate.Commands;
using ContentService.Core.AggregateModel.ContentAggregate.Queries;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;

namespace ContentService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class ContentController
{
    private readonly IMediator _mediator;

    private readonly ILogger<ContentController> _logger;

    public ContentController(IMediator mediator,ILogger<ContentController> logger){
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [SwaggerOperation(
        Summary = "Update ContentId",
        Description = @"Update ContentId"
    )]
    [HttpPut(Name = "updateContentId")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UpdateContentResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateContentResponse>> Update([FromBody]UpdateContentRequest  request,CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Create Content",
        Description = @"Create Content"
    )]
    [HttpPost(Name = "createContent")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(CreateContentResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CreateContentResponse>> Create([FromBody]CreateContentRequest  request,CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get Contents",
        Description = @"Get Contents"
    )]
    [HttpGet(Name = "getContents")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetContentsResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetContentsResponse>> Get(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetContentsRequest(), cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get ContentId  by id",
        Description = @"Get ContentId by id"
    )]
    [HttpGet("{contentId:guid}", Name = "getContentIdById")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetContentByIdResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetContentByIdResponse>> GetById([FromRoute]Guid contentId,CancellationToken cancellationToken)
    {
        var request = new GetContentByIdRequest(){ContentId = contentId};

        var response = await _mediator.Send(request, cancellationToken);

        if (response.Content == null)
        {
            return new NotFoundObjectResult(request.ContentId);
        }

        return response;
    }

    [SwaggerOperation(
        Summary = "Delete Content",
        Description = @"Delete Content"
    )]
    [HttpDelete("{contentId:guid}", Name = "deleteContent")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(DeleteContentResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<DeleteContentResponse>> Delete([FromRoute]Guid contentId,CancellationToken cancellationToken)
    {
        var request = new DeleteContentRequest() {ContentId = contentId };

        return await _mediator.Send(request, cancellationToken);
    }

}


