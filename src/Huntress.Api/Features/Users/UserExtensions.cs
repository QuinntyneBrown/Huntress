using System;
using Huntress.Api.Models;

namespace Huntress.Api.Features
{
    public static class UserExtensions
    {
        public static UserDto ToDto(this User user)
        {
            return new()
            {
                UserId = user.UserId
            };
        }

    }
}
