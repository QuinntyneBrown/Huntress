// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Http;

namespace DashboardService.Core.AggregateModel.DashboardAggregate.Queries;

public class GetDashboardsByCurrentUserRequest: IRequest<GetDashboardsByCurrentUserResponse> { }

public class GetDashboardsByCurrentUserResponse: ResponseBase
{
    public List<DashboardDto> Dashboards { get; set; }
}


public class GetDashboardsByCurrentUserRequestHandler: IRequestHandler<GetDashboardsByCurrentUserRequest,GetDashboardsByCurrentUserResponse>
{
    private readonly ILogger<GetDashboardsByCurrentUserRequestHandler> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IDashboardServiceDbContext _context;

    public GetDashboardsByCurrentUserRequestHandler(
        ILogger<GetDashboardsByCurrentUserRequestHandler> logger,
        IDashboardServiceDbContext context,
        IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    public async Task<GetDashboardsByCurrentUserResponse> Handle(GetDashboardsByCurrentUserRequest request,CancellationToken cancellationToken){

        _logger.LogInformation("Get Dashboards for current user");

        var name = _httpContextAccessor!.HttpContext!.User.Identity!.Name;
        
        var user = _context.Users.Single(x => x.Username == name);

        var dashboards = await _context.Dashboards.Where(x => x.UserId == user.UserId)
            .Include(x => x.DashboardCards)
            .Select(x => x.ToDto())
            .ToListAsync();

        return new GetDashboardsByCurrentUserResponse()
        {
            Dashboards = dashboards
        };
    }

}



