namespace OtpService.Core.AggregateModel.UserAggregate.Commands;

public class DeleteUserRequestValidator: AbstractValidator<DeleteUserRequest> { }

public class DeleteUserRequest: IRequest<DeleteUserResponse>
{
    public Guid UserId { get; set; }
}


public class DeleteUserResponse
{
    public UserDto User { get; set; }
}


public class DeleteUserRequestHandler: IRequestHandler<DeleteUserRequest,DeleteUserResponse>
{
    private readonly ILogger<DeleteUserRequestHandler> _logger;

    private readonly IOtpServiceDbContext _context;

    public DeleteUserRequestHandler(ILogger<DeleteUserRequestHandler> logger,IOtpServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<DeleteUserResponse> Handle(DeleteUserRequest request,CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.UserId);

        _context.Users.Remove(user);

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            User = user.ToDto()
        };
    }

}


