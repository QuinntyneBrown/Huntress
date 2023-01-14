using IdentityService.Core.AggregateModel.PrivilegeAggregate;
using IdentityService.Core.AggregateModel.RoleAggregate;
using IdentityService.Core.AggregateModel.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Infrastructure.Data;

public interface IIdentityServiceDbContext
{
    public DbSet<Privilege> Privileges { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}

