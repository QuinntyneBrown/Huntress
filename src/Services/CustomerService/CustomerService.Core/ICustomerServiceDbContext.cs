using CustomerService.Core.AggregateModel.CustomerAggregate;

namespace CustomerService.Core;

public interface ICustomerServiceDbContext
{
    public DbSet<Customer> Customers { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}

