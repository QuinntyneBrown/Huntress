using Huntress.Domain.Entities;
using System.Linq;

namespace Huntress.Api.Features
{
    public static class RoleExtensions
    {
        public static RoleDto ToDto(this Role role)
        {
            return new()
            {
                RoleId = role?.RoleId,
                Name = role?.Name,
                Privileges = role?.Privileges?.Select(x => x.ToDto()).ToList(),
                AggregatePrivileges = role?.Privileges
                .OrderBy(x => x.Aggregate)
                .ThenBy(x => x.AccessRight)
                .GroupBy(x => x.Aggregate)
                .Select(g => new AggregatePrivilegeDto
                {
                    Aggregate = g.Key,
                    Privileges = g.Select(x => x.ToDto()).ToList()
                })
                .ToList()
            };
        }

    }
}
