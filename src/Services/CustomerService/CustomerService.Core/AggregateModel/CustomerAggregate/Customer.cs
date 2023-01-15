namespace CustomerService.Core.AggregateModel.CustomerAggregate;

public class Customer
{
    public Guid CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}

