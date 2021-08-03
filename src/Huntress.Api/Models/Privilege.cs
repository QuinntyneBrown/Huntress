using System;

namespace Huntress.Api.Models
{

    public class Privilege
    {
        public Guid PrivilegeId { get; private set; }
        public AccessRight AccessRight { get; private set; }
        public string Aggregate { get; private set; }
        public Privilege(AccessRight accessRight, string aggregate)
        {
            AccessRight = accessRight;
            Aggregate = aggregate;
        }

        private Privilege()
        {

        }
    }
}
