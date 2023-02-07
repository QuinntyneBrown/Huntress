// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using CustomerService.Core.AggregateModel.CustomerAggregate.Commands;
using CustomerService.Core.AggregateModel.CustomerAggregate.Queries;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CustomerService.Core;

namespace CustomerService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController
{
    private readonly IMediator _mediator;

    private readonly ILogger<CustomerController> _logger;

    public CustomerController(IMediator mediator,ILogger<CustomerController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

/*    public async Task<ActionResult<UpdateCustomerResponse>> Update(UpdateCustomerRequest  request,CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    public async Task<ActionResult<CreateCustomerResponse>> Create(CreateCustomerRequest  request,CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }*/

    [HttpGet]
    public async Task<ActionResult<GetCustomersResponse>> Get(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetCustomersRequest(), cancellationToken);
    }
/*
    public async Task<ActionResult<GetCustomerByIdResponse>> GetById(Guid customerId,CancellationToken cancellationToken)
    {
        var request = new GetCustomerByIdRequest(){CustomerId = customerId};

        var response = await _mediator.Send(request, cancellationToken);

        if (response.Customer == null)
        {
            return new NotFoundObjectResult(request.CustomerId);
        }

        return response;
    }

    public async Task<ActionResult<DeleteCustomerResponse>> Delete(Guid customerId,CancellationToken cancellationToken)
    {
        var request = new DeleteCustomerRequest() {CustomerId = customerId };

        return await _mediator.Send(request, cancellationToken);
    }*/

}


