using Huntress.Domain.Enums;

namespace Huntress.Domain.Entities;

public class Privilege
{
    public Guid PrivilegeId { get; private set; }
    public Guid RoleId { get; private set; }
    public AccessRight AccessRight { get; private set; }
    public string Aggregate { get; private set; } = "";
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
