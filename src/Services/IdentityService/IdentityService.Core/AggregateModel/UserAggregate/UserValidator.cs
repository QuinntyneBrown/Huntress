using FluentValidation;

namespace IdentityService.Core.AggregateModel.UserAggregate;

public class UserValidator: AbstractValidator<UserDto>
{
    public UserValidator()
    {
        RuleFor(x => x.Username).NotEmpty();
    }
}
