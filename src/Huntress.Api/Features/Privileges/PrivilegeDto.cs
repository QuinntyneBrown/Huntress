using Huntress.Domain.Entities;
using System;

namespace Huntress.Api.Features
{
    public class PrivilegeDto
    {
        public Guid PrivilegeId { get; set; }
        public Guid RoleId { get; set; }
        public AccessRight AccessRight { get; set; }
        public string Aggregate { get; set; }
    }
}
