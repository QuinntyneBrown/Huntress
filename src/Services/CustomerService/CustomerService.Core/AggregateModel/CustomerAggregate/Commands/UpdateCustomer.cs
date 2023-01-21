namespace CustomerService.Core.AggregateModel.CustomerAggregate.Commands;

public class UpdateCustomerRequestValidator: AbstractValidator<UpdateCustomerRequest> { }

public class UpdateCustomerRequest: IRequest<UpdateCustomerResponse>
{
    public Guid CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}


public class UpdateCustomerResponse
{
    public CustomerDto Customer { get; set; }
}


public class UpdateCustomerRequestHandler: IRequestHandler<UpdateCustomerRequest,UpdateCustomerResponse>
{
    private readonly ILogger<UpdateCustomerRequestHandler> _logger;

    private readonly ICustomerServiceDbContext _context;

    public UpdateCustomerRequestHandler(ILogger<UpdateCustomerRequestHandler> logger,ICustomerServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest request,CancellationToken cancellationToken)
    {
        var customer = await _context.Customers.SingleAsync(x => x.CustomerId == request.CustomerId);

        customer.CustomerId = request.CustomerId;
        customer.FirstName = request.FirstName;
        customer.LastName = request.LastName;
        customer.Email = request.Email;
        customer.PhoneNumber = request.PhoneNumber;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Customer = customer.ToDto()
        };

    }

}


