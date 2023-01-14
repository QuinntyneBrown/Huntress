using IdentityService.Core;
using IdentityService.Core.Entities;
using IdentityService.Core.User;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure;

public class IdentityServiceDbContext: DbContext, IIdentityServiceDbContext
{
    public DbSet<User> Users { get; private set; }
    public DbSet<Role> Roles { get; private set; }
    public DbSet<Privilege> Privileges { get; private set; }
}
