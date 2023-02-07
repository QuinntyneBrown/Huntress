// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace OtpService.Core.AggregateModel.UserAggregate.Queries;

public class GetUserByIdRequest: IRequest<GetUserByIdResponse>
{
    public Guid UserId { get; set; }
}


public class GetUserByIdResponse
{
    public UserDto User { get; set; }
}


public class GetUserByIdRequestHandler: IRequestHandler<GetUserByIdRequest,GetUserByIdResponse>
{
    private readonly ILogger<GetUserByIdRequestHandler> _logger;

    private readonly IOtpServiceDbContext _context;

    public GetUserByIdRequestHandler(ILogger<GetUserByIdRequestHandler> logger,IOtpServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request,CancellationToken cancellationToken)
    {
        return new () {
            User = (await _context.Users.AsNoTracking().SingleOrDefaultAsync(x => x.UserId == request.UserId)).ToDto()
        };

    }

}



