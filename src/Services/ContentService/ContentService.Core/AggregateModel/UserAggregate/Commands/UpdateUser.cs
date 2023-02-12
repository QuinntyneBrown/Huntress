// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.UserAggregate.Commands;

public class UpdateUserRequestValidator: AbstractValidator<UpdateUserRequest> { }

public class UpdateUserRequest: IRequest<UpdateUserResponse>
{
    public string Username { get; set; }
    public Guid UserId { get; set; }
}


public class UpdateUserResponse: ResponseBase
{
    public UserDto User { get; set; }
}


public class UpdateUserRequestHandler: IRequestHandler<UpdateUserRequest,UpdateUserResponse>
{
    private readonly ILogger<UpdateUserRequestHandler> _logger;

    private readonly IContentServiceDbContext _context;

    public UpdateUserRequestHandler(ILogger<UpdateUserRequestHandler> logger,IContentServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request,CancellationToken cancellationToken)
    {
        var user = await _context.Users.SingleAsync(x => x.UserId == request.UserId);

        user.Username = request.Username;
        user.UserId = request.UserId;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            User = user.ToDto()
        };

    }

}



