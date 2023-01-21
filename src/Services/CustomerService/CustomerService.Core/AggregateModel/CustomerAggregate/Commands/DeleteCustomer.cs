namespace CustomerService.Core.AggregateModel.CustomerAggregate.Commands;

public class DeleteCustomerRequestValidator: AbstractValidator<DeleteCustomerRequest> { }

public class DeleteCustomerRequest: IRequest<DeleteCustomerResponse>
{
    public Guid CustomerId { get; set; }
}


public class DeleteCustomerResponse
{
    public CustomerDto Customer { get; set; }
}


public class DeleteCustomerRequestHandler: IRequestHandler<DeleteCustomerRequest,DeleteCustomerResponse>
{
    private readonly ILogger<DeleteCustomerRequestHandler> _logger;

    private readonly ICustomerServiceDbContext _context;

    public DeleteCustomerRequestHandler(ILogger<DeleteCustomerRequestHandler> logger,ICustomerServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<DeleteCustomerResponse> Handle(DeleteCustomerRequest request,CancellationToken cancellationToken)
    {
        var customer = await _context.Customers.FindAsync(request.CustomerId);

        _context.Customers.Remove(customer);

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Customer = customer.ToDto()
        };
    }

}


