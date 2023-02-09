// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace IdentityService.Core.AggregateModel.PrivilegeAggregate.Commands;

public class CreatePrivilegeRequestValidator: AbstractValidator<CreatePrivilegeRequest> { }

public class CreatePrivilegeRequest: IRequest<CreatePrivilegeResponse>
{
    public Guid PrivilegeId { get; set; }
}


public class CreatePrivilegeResponse: ResponseBase
{
    public PrivilegeDto Privilege { get; set; }
}


public class CreatePrivilegeRequestHandler: IRequestHandler<CreatePrivilegeRequest,CreatePrivilegeResponse>
{
    private readonly ILogger<CreatePrivilegeRequestHandler> _logger;

    private readonly IIdentityServiceDbContext _context;

    public CreatePrivilegeRequestHandler(ILogger<CreatePrivilegeRequestHandler> logger,IIdentityServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<CreatePrivilegeResponse> Handle(CreatePrivilegeRequest request,CancellationToken cancellationToken)
    {
        var privilege = new Privilege();

        _context.Privileges.Add(privilege);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Privilege = privilege.ToDto()
        };
    }
}