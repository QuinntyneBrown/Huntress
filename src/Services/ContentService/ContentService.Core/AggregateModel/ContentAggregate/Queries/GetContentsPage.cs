// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.ContentAggregate.Queries;

public class GetContentsPageRequest : IRequest<GetContentsPageResponse>
{
    public int PageSize { get; set; }
    public int Index { get; set; }
}


public class GetContentsPageResponse : ResponseBase
{
    public int Length { get; set; }
    public List<ContentDto> Entities { get; set; }
}


public class GetContentsPageRequestHandler : IRequestHandler<GetContentsPageRequest, GetContentsPageResponse>
{
    private readonly ILogger<GetContentsPageRequestHandler> _logger;

    private readonly IContentServiceDbContext _context;

    public GetContentsPageRequestHandler(ILogger<GetContentsPageRequestHandler> logger, IContentServiceDbContext context)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetContentsPageResponse> Handle(GetContentsPageRequest request, CancellationToken cancellationToken)
    {
        var query = from content in _context.Contents
                    select content;

        var length = await _context.Contents.AsNoTracking().CountAsync();

        var contents = await query.Page(request.Index, request.PageSize).AsNoTracking()
            .Select(x => x.ToDto()).ToListAsync();

        return new()
        {
            Length = length,
            Entities = contents
        };

    }

}



