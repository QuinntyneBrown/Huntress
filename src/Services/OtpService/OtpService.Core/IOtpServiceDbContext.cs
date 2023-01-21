using OtpService.Core.AggregateModel.UserAggregate;

namespace OtpService.Core;

public interface IOtpServiceDbContext
{
    DbSet<User> Users { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}