namespace OtpService.Core.AggregateModel.UserAggregate.Commands;

public class UpdateUserRequestValidator: AbstractValidator<UpdateUserRequest> { }

public class UpdateUserRequest: IRequest<UpdateUserResponse>
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
}


public class UpdateUserResponse
{
    public UserDto User { get; set; }
}


public class UpdateUserRequestHandler: IRequestHandler<UpdateUserRequest,UpdateUserResponse>
{
    private readonly ILogger<UpdateUserRequestHandler> _logger;

    private readonly IOtpServiceDbContext _context;

    public UpdateUserRequestHandler(ILogger<UpdateUserRequestHandler> logger,IOtpServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request,CancellationToken cancellationToken)
    {
        var user = await _context.Users.SingleAsync(x => x.UserId == request.UserId);

        user.UserId = request.UserId;
        user.Username = request.Username;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            User = user.ToDto()
        };

    }

}


