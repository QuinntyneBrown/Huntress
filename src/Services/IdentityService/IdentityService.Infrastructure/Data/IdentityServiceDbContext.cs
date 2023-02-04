using IdentityService.Core;
using IdentityService.Core.AggregateModel.PrivilegeAggregate;
using IdentityService.Core.AggregateModel.RoleAggregate;
using IdentityService.Core.AggregateModel.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Infrastructure.Data;

public class IdentityServiceDbContext: DbContext, IIdentityServiceDbContext
{
    public IdentityServiceDbContext(DbContextOptions<IdentityServiceDbContext> options)
        :base(options)
    {
        
    }

    public DbSet<Privilege> Privileges { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }

}

