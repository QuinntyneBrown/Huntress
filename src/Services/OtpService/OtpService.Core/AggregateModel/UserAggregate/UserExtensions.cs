namespace OtpService.Core.AggregateModel.UserAggregate;

public static class UserExtensions
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            UserId = user.UserId,
            Username = user.Username,
        };

    }

    public async static Task<List<UserDto>> ToDtosAsync(this IQueryable<User> users,CancellationToken cancellationToken)
    {
        return await users.Select(x => x.ToDto()).ToListAsync(cancellationToken);
    }

}

