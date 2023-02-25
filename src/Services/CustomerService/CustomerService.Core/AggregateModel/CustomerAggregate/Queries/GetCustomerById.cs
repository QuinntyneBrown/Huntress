// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CustomerService.Core.AggregateModel.CustomerAggregate.Queries;

public class GetCustomerByIdRequest : IRequest<GetCustomerByIdResponse>
{
    public Guid CustomerId { get; set; }
}


public class GetCustomerByIdResponse
{
    public CustomerDto Customer { get; set; }
}


public class GetCustomerByIdRequestHandler : IRequestHandler<GetCustomerByIdRequest, GetCustomerByIdResponse>
{
    private readonly ILogger<GetCustomerByIdRequestHandler> _logger;

    private readonly ICustomerServiceDbContext _context;

    public GetCustomerByIdRequestHandler(ILogger<GetCustomerByIdRequestHandler> logger, ICustomerServiceDbContext context)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetCustomerByIdResponse> Handle(GetCustomerByIdRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            Customer = (await _context.Customers.AsNoTracking().SingleOrDefaultAsync(x => x.CustomerId == request.CustomerId)).ToDto()
        };

    }

}



