// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContentService.Core.AggregateModel.JsonSchemaModelAggregate.Commands;
using ContentService.Core.AggregateModel.JsonSchemaModelAggregate.Queries;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;

namespace ContentService.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class JsonSchemaModelController
{
    private readonly IMediator _mediator;

    private readonly ILogger<JsonSchemaModelController> _logger;

    public JsonSchemaModelController(IMediator mediator,ILogger<JsonSchemaModelController> logger){
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [SwaggerOperation(
        Summary = "Update JsonSchemaModelId",
        Description = @"Update JsonSchemaModelId"
    )]
    [HttpPut(Name = "updateJsonSchemaModelId")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UpdateJsonSchemaModelResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateJsonSchemaModelResponse>> Update([FromBody]UpdateJsonSchemaModelRequest  request,CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Create JsonSchemaModel",
        Description = @"Create JsonSchemaModel"
    )]
    [HttpPost(Name = "createJsonSchemaModel")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(CreateJsonSchemaModelResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CreateJsonSchemaModelResponse>> Create([FromBody]CreateJsonSchemaModelRequest  request,CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get JsonSchemaModels",
        Description = @"Get JsonSchemaModels"
    )]
    [HttpGet(Name = "getJsonSchemaModels")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetJsonSchemaModelsResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetJsonSchemaModelsResponse>> Get(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetJsonSchemaModelsRequest(), cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get JsonSchemaModelId  by id",
        Description = @"Get JsonSchemaModelId by id"
    )]
    [HttpGet("{jsonSchemaModelId:guid}", Name = "getJsonSchemaModelIdById")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetJsonSchemaModelByIdResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetJsonSchemaModelByIdResponse>> GetById([FromRoute]Guid jsonSchemaModelId,CancellationToken cancellationToken)
    {
        var request = new GetJsonSchemaModelByIdRequest(){JsonSchemaModelId = jsonSchemaModelId};

        var response = await _mediator.Send(request, cancellationToken);

        if (response.JsonSchemaModel == null)
        {
            return new NotFoundObjectResult(request.JsonSchemaModelId);
        }

        return response;
    }

    [SwaggerOperation(
        Summary = "Delete JsonSchemaModel",
        Description = @"Delete JsonSchemaModel"
    )]
    [HttpDelete("{jsonSchemaModelId:guid}", Name = "deleteJsonSchemaModel")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(DeleteJsonSchemaModelResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<DeleteJsonSchemaModelResponse>> Delete([FromRoute]Guid jsonSchemaModelId,CancellationToken cancellationToken)
    {
        var request = new DeleteJsonSchemaModelRequest() {JsonSchemaModelId = jsonSchemaModelId };

        return await _mediator.Send(request, cancellationToken);
    }

}


