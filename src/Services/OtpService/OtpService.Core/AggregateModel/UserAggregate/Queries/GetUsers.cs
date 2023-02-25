// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace OtpService.Core.AggregateModel.UserAggregate.Queries;

public class GetUsersRequest : IRequest<GetUsersResponse> { }

public class GetUsersResponse
{
    public List<UserDto> Users { get; set; }
}


public class GetUsersRequestHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
{
    private readonly ILogger<GetUsersRequestHandler> _logger;

    private readonly IOtpServiceDbContext _context;

    public GetUsersRequestHandler(ILogger<GetUsersRequestHandler> logger, IOtpServiceDbContext context)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            Users = await _context.Users.AsNoTracking().ToDtosAsync(cancellationToken)
        };

    }

}



