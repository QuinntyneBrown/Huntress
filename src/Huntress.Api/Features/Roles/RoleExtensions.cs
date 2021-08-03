using System;
using System.Linq;
using Huntress.Api.Models;

namespace Huntress.Api.Features
{
    public static class RoleExtensions
    {
        public static RoleDto ToDto(this Role role)
        {
            return new()
            {
                RoleId = role.RoleId,
                Name = role.Name,
                Privileges = role.Privileges.Select(x => x.ToDto()).ToList()
            };
        }

    }
}
