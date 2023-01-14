using IdentityService.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Core;

public interface IIdentityServiceDbContext {

    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    DbSet<Privilege> Privileges { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}
