namespace CustomerService.Core.AggregateModel.CustomerAggregate;

public static class CustomerExtensions
{
    public static CustomerDto ToDto(this Customer customer)
    {
        return new CustomerDto
        {
            CustomerId = customer.CustomerId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
        };

    }

    public async static Task<List<CustomerDto>> ToDtosAsync(this IQueryable<Customer> customers,CancellationToken cancellationToken)
    {
        return await customers.Select(x => x.ToDto()).ToListAsync(cancellationToken);
    }

}

