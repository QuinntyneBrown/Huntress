using Huntress.Api.Models;
using System.Linq;

namespace Huntress.Api.Features
{
    public static class UserExtensions
    {
        public static UserDto ToDto(this User user)
        {
            return new()
            {
                UserId = user.UserId,
                Username = user.Username,
                Roles = user.Roles.Select(x => x.ToDto()).ToList()
            };
        }

    }
}
