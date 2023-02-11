// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using DashboardService.Core.AggregateModel.DashboardAggregate.Commands;
using DashboardService.Core.AggregateModel.DashboardAggregate.Queries;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;

namespace DashboardService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class DashboardController
{
    private readonly IMediator _mediator;

    private readonly ILogger<DashboardController> _logger;

    public DashboardController(IMediator mediator,ILogger<DashboardController> logger){
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [SwaggerOperation(
        Summary = "Update DashboardId",
        Description = @"Update DashboardId"
    )]
    [HttpPut(Name = "updateDashboardId")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UpdateDashboardResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateDashboardResponse>> Update([FromBody]UpdateDashboardRequest  request,CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Create Dashboard",
        Description = @"Create Dashboard"
    )]
    [HttpPost(Name = "createDashboard")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(CreateDashboardResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CreateDashboardResponse>> Create([FromBody]CreateDashboardRequest  request,CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get Dashboards",
        Description = @"Get Dashboards"
    )]
    [HttpGet(Name = "getDashboards")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetDashboardsResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetDashboardsResponse>> Get(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetDashboardsRequest(), cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get DashboardId  by id",
        Description = @"Get DashboardId by id"
    )]
    [HttpGet("{toDoId:guid}", Name = "getDashboardIdById")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetDashboardByIdResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetDashboardByIdResponse>> GetById([FromRoute]Guid dashboardId,CancellationToken cancellationToken)
    {
        var request = new GetDashboardByIdRequest(){DashboardId = dashboardId};

        var response = await _mediator.Send(request, cancellationToken);

        if (response.Dashboard == null)
        {
            return new NotFoundObjectResult(request.DashboardId);
        }

        return response;
    }

    [SwaggerOperation(
        Summary = "Delete Dashboard",
        Description = @"Delete Dashboard"
    )]
    [HttpDelete("{toDoId:guid}", Name = "deleteDashboard")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(DeleteDashboardResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<DeleteDashboardResponse>> Delete([FromRoute]Guid dashboardId,CancellationToken cancellationToken)
    {
        var request = new DeleteDashboardRequest() {DashboardId = dashboardId };

        return await _mediator.Send(request, cancellationToken);
    }

}


