// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using IdentityService.Core.AggregateModel.PrivilegeAggregate;
using IdentityService.Core.AggregateModel.UserAggregate;

namespace IdentityService.Core.AggregateModel.RoleAggregate.Commands;

public class UpdateRoleRequestValidator: AbstractValidator<UpdateRoleRequest> { }

public class UpdateRoleRequest: IRequest<UpdateRoleResponse>
{
    public Guid RoleId { get; set; }
    public string Name { get; set; }
    public List<UserDto> Users { get; set; }
    public List<PrivilegeDto> Privileges { get; set; }
}


public class UpdateRoleResponse: ResponseBase
{
    public RoleDto Role { get; set; }
}


public class UpdateRoleRequestHandler: IRequestHandler<UpdateRoleRequest,UpdateRoleResponse>
{
    private readonly ILogger<UpdateRoleRequestHandler> _logger;

    private readonly IIdentityServiceDbContext _context;

    public UpdateRoleRequestHandler(ILogger<UpdateRoleRequestHandler> logger,IIdentityServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UpdateRoleResponse> Handle(UpdateRoleRequest request,CancellationToken cancellationToken)
    {
        var role = await _context.Roles.SingleAsync(x => x.RoleId == request.RoleId);

        role.RoleId = request.RoleId;
        role.Name = request.Name;
        //role.Users = request.Users.Select(x => x.ToDto);
        //role.Privileges = request.Privileges;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Role = role.ToDto()
        };

    }

}



