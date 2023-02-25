// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using CustomerService.Core.AggregateModel.CustomerAggregate.Commands;
using CustomerService.Core.AggregateModel.CustomerAggregate.Queries;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;

namespace CustomerService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class CustomerController
{
    private readonly IMediator _mediator;

    private readonly ILogger<CustomerController> _logger;

    public CustomerController(IMediator mediator, ILogger<CustomerController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [SwaggerOperation(
        Summary = "Update CustomerId",
        Description = @"Update CustomerId"
    )]
    [HttpPut(Name = "updateCustomerId")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UpdateCustomerResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateCustomerResponse>> Update([FromBody] UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Create Customer",
        Description = @"Create Customer"
    )]
    [HttpPost(Name = "createCustomer")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(CreateCustomerResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CreateCustomerResponse>> Create([FromBody] CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get Customers",
        Description = @"Get Customers"
    )]
    [HttpGet(Name = "getCustomers")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetCustomersResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCustomersResponse>> Get(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetCustomersRequest(), cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get CustomerId  by id",
        Description = @"Get CustomerId by id"
    )]
    [HttpGet("{customerId:guid}", Name = "getCustomerIdById")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetCustomerByIdResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCustomerByIdResponse>> GetById([FromRoute] Guid customerId, CancellationToken cancellationToken)
    {
        var request = new GetCustomerByIdRequest() { CustomerId = customerId };

        var response = await _mediator.Send(request, cancellationToken);

        if (response.Customer == null)
        {
            return new NotFoundObjectResult(request.CustomerId);
        }

        return response;
    }

    [SwaggerOperation(
        Summary = "Delete Customer",
        Description = @"Delete Customer"
    )]
    [HttpDelete("{customerId:guid}", Name = "deleteCustomer")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(DeleteCustomerResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<DeleteCustomerResponse>> Delete([FromRoute] Guid customerId, CancellationToken cancellationToken)
    {
        var request = new DeleteCustomerRequest() { CustomerId = customerId };

        return await _mediator.Send(request, cancellationToken);
    }

}


