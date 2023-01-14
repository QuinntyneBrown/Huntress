using Security;

namespace IdentityService.Core.AggregateModel.PrivilegeAggregate;

public class Privilege
{
    public Guid PrivilegeId { get; init; }
    public Guid RoleId { get; init; }
    public AccessRight AccessRight { get; init; }
    public string Aggregate { get; init; }
    public Privilege(Guid roleId, AccessRight accessRight, string aggregate)
    {
        RoleId = roleId;
        AccessRight = accessRight;
        Aggregate = aggregate;
    }

    public Privilege(AccessRight accessRight, string aggregate)
    {
        AccessRight = accessRight;
        Aggregate = aggregate;
    }

    private Privilege()
    {

    }
}