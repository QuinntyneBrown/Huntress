using CustomerService.Core;
using CustomerService.Core.AggregateModel.CustomerAggregate;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Infrastructure.Data;

public class CustomerServiceDbContext: DbContext, ICustomerServiceDbContext
{
    public CustomerServiceDbContext(DbContextOptions<CustomerServiceDbContext> options)
        :base(options)
    { }

    public DbSet<Customer> Customers { get; set; }
}