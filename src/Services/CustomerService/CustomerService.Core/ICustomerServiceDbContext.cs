// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using CustomerService.Core.AggregateModel.CustomerAggregate;

namespace CustomerService.Core;

public interface ICustomerServiceDbContext
{
    public DbSet<Customer> Customers { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}


