// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using IdentityService.Core;
using Microsoft.EntityFrameworkCore;
using IdentityService.Core.AggregateModel.PrivilegeAggregate;
using IdentityService.Core.AggregateModel.RoleAggregate;
using IdentityService.Core.AggregateModel.UserAggregate;

namespace IdentityService.Core;

public interface IIdentityServiceDbContext
{
    public DbSet<Privilege> Privileges { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}
