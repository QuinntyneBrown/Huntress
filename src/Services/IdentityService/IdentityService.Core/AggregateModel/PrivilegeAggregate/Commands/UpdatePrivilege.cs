// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace IdentityService.Core.AggregateModel.PrivilegeAggregate.Commands;

public class UpdatePrivilegeRequestValidator: AbstractValidator<UpdatePrivilegeRequest> { }

public class UpdatePrivilegeRequest: IRequest<UpdatePrivilegeResponse>
{
    public Guid PrivilegeId { get; set; }
}


public class UpdatePrivilegeResponse: ResponseBase
{
    public PrivilegeDto Privilege { get; set; }
}


public class UpdatePrivilegeRequestHandler: IRequestHandler<UpdatePrivilegeRequest,UpdatePrivilegeResponse>
{
    private readonly ILogger<UpdatePrivilegeRequestHandler> _logger;

    private readonly IIdentityServiceDbContext _context;

    public UpdatePrivilegeRequestHandler(ILogger<UpdatePrivilegeRequestHandler> logger,IIdentityServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UpdatePrivilegeResponse> Handle(UpdatePrivilegeRequest request,CancellationToken cancellationToken)
    {
        var privilege = await _context.Privileges.SingleAsync(x => x.PrivilegeId == request.PrivilegeId);

        privilege.PrivilegeId = request.PrivilegeId;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Privilege = privilege.ToDto()
        };

    }

}



