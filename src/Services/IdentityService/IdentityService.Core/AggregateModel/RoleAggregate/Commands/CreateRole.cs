// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using IdentityService.Core.AggregateModel.PrivilegeAggregate;
using IdentityService.Core.AggregateModel.UserAggregate;

namespace IdentityService.Core.AggregateModel.RoleAggregate.Commands;

public class CreateRoleRequestValidator: AbstractValidator<CreateRoleRequest> { }

public class CreateRoleRequest: IRequest<CreateRoleResponse>
{
    public Guid RoleId { get; set; }
    public string Name { get; set; }
    public List<UserDto> Users { get; set; }
    public List<PrivilegeDto> Privileges { get; set; }
}


public class CreateRoleResponse: ResponseBase
{
    public RoleDto Role { get; set; }
}


public class CreateRoleRequestHandler: IRequestHandler<CreateRoleRequest,CreateRoleResponse>
{
    private readonly ILogger<CreateRoleRequestHandler> _logger;

    private readonly IIdentityServiceDbContext _context;

    public CreateRoleRequestHandler(ILogger<CreateRoleRequestHandler> logger,IIdentityServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<CreateRoleResponse> Handle(CreateRoleRequest request,CancellationToken cancellationToken)
    {
        var role = new Role();

        _context.Roles.Add(role);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Role = role.ToDto()
        };
    }
}
