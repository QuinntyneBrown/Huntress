using Huntress.Api.Models;

namespace Huntress.Api.Features
{
    public static class PrivilegeExtensions
    {
        public static PrivilegeDto ToDto(this Privilege privilege)
        {
            return new()
            {
                PrivilegeId = privilege.PrivilegeId,
                AccessRight = privilege.AccessRight,
                Aggregate = privilege.Aggregate
            };
        }
    }
}
