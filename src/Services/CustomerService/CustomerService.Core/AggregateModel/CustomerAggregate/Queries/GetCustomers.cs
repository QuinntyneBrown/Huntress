// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CustomerService.Core.AggregateModel.CustomerAggregate.Queries;

public class GetCustomersRequest: IRequest<GetCustomersResponse> { }

public class GetCustomersResponse
{
    public List<CustomerDto> Customers { get; set; }
}


public class GetCustomersRequestHandler: IRequestHandler<GetCustomersRequest,GetCustomersResponse>
{
    private readonly ILogger<GetCustomersRequestHandler> _logger;

    private readonly ICustomerServiceDbContext _context;

    public GetCustomersRequestHandler(ILogger<GetCustomersRequestHandler> logger,ICustomerServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetCustomersResponse> Handle(GetCustomersRequest request,CancellationToken cancellationToken)
    {
        return new () {
            Customers = await _context.Customers.AsNoTracking().ToDtosAsync(cancellationToken)
        };

    }

}



