// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using IdentityService.Core.AggregateModel.RoleAggregate;

namespace IdentityService.Core.AggregateModel.UserAggregate;

public static class UserExtensions
{
    public static UserDto ToDo(this User user)
    {
        return new UserDto
        {
            UserId = user.UserId,
            Username = user.Username,
            Roles = user.Roles.Select(x => new RoleDto()).ToList()
        };
    }
}



