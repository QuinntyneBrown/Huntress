using System.Collections.Generic;

namespace Huntress.Api.Features
{
    public class AggregatePrivilegeDto
    {
        public string Aggregate { get; set; }
        public List<PrivilegeDto> Privileges { get; set; } = new();
    }
}
