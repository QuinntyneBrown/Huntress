// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.ContentAggregate.Queries;

public class GetContentByNameRequest : IRequest<GetContentByNameResponse>
{
    public required string Name { get; set; }
}

public class GetContentByNameResponse : ResponseBase
{
    public required ContentDto Content { get; set; }
}


public class GetContentByNameRequestHandler : IRequestHandler<GetContentByNameRequest, GetContentByNameResponse>
{
    private readonly ILogger<GetContentByNameRequestHandler> _logger;

    private readonly IContentServiceDbContext _context;

    public GetContentByNameRequestHandler(ILogger<GetContentByNameRequestHandler> logger, IContentServiceDbContext context)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetContentByNameResponse> Handle(GetContentByNameRequest request, CancellationToken cancellationToken)
    {

        return new()
        {
            Content = _context.Contents.Single(x => x.Name == request.Name).ToDto()
        };
    }

}



