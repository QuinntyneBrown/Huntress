// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.UserAggregate;

public static class UserExtensions
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Username = user.Username,
            UserId = user.UserId,
        };

    }

    public async static Task<List<UserDto>> ToDtosAsync(this IQueryable<User> users, CancellationToken cancellationToken)
    {
        return await users.Select(x => x.ToDto()).ToListAsync(cancellationToken);
    }

}


