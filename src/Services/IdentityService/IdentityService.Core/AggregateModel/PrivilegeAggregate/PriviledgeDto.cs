using Security;

namespace IdentityService.Core.AggregateModel.PrivilegeAggregate;

public class PrivilegeDto
{
    public Guid? PrivilegeId { get; init; }
    public Guid? RoleId { get; init; }
    public AccessRight AccessRight { get; init; }
    public string Aggregate { get; init; }
}
