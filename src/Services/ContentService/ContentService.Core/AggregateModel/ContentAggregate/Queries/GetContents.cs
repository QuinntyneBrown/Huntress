// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.ContentAggregate.Queries;

public class GetContentsRequest: IRequest<GetContentsResponse> { }

public class GetContentsResponse: ResponseBase
{
    public List<ContentDto> Contents { get; set; }
}


public class GetContentsRequestHandler: IRequestHandler<GetContentsRequest,GetContentsResponse>
{
    private readonly ILogger<GetContentsRequestHandler> _logger;

    private readonly IContentServiceDbContext _context;

    public GetContentsRequestHandler(ILogger<GetContentsRequestHandler> logger,IContentServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetContentsResponse> Handle(GetContentsRequest request,CancellationToken cancellationToken)
    {
        return new () {
            Contents = await _context.Contents.AsNoTracking().ToDtosAsync(cancellationToken)
        };

    }

}



