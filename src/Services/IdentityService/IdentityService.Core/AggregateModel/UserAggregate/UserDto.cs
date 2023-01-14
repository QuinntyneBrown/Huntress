using IdentityService.Core.AggregateModel.RoleAggregate;

namespace IdentityService.Core.AggregateModel.UserAggregate;

public class UserDto
{
    public Guid? UserId { get; set; }
    public string Username { get; set; }
    public List<RoleDto> Roles { get; set; }
}
