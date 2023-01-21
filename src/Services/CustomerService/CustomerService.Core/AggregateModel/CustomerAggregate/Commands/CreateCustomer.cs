namespace CustomerService.Core.AggregateModel.CustomerAggregate.Commands;

public class CreateCustomerRequestValidator: AbstractValidator<CreateCustomerRequest> { }

public class CreateCustomerRequest: IRequest<CreateCustomerResponse>
{
    public Guid CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}


public class CreateCustomerResponse: ResponseBase
{
    public CustomerDto Customer { get; set; }
}


public class CreateCustomerRequestHandler: IRequestHandler<CreateCustomerRequest,CreateCustomerResponse>
{
    private readonly ILogger<CreateCustomerRequestHandler> _logger;

    private readonly ICustomerServiceDbContext _context;

    public CreateCustomerRequestHandler(ILogger<CreateCustomerRequestHandler> logger,ICustomerServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request,CancellationToken cancellationToken)
    {
        var customer = new Customer();

        _context.Customers.Add(customer);

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


