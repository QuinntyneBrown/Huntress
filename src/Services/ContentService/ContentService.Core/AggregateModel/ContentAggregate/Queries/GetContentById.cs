// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.ContentAggregate.Queries;

public class GetContentByIdRequest : IRequest<GetContentByIdResponse>
{
    public Guid ContentId { get; set; }
}


public class GetContentByIdResponse : ResponseBase
{
    public ContentDto Content { get; set; }
}


public class GetContentByIdRequestHandler : IRequestHandler<GetContentByIdRequest, GetContentByIdResponse>
{
    private readonly ILogger<GetContentByIdRequestHandler> _logger;

    private readonly IContentServiceDbContext _context;

    public GetContentByIdRequestHandler(ILogger<GetContentByIdRequestHandler> logger, IContentServiceDbContext context)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetContentByIdResponse> Handle(GetContentByIdRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            Content = (await _context.Contents.AsNoTracking().SingleOrDefaultAsync(x => x.ContentId == request.ContentId)).ToDto()
        };

    }

}



