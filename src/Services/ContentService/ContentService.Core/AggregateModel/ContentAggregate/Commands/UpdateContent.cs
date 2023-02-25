// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json.Linq;

namespace ContentService.Core.AggregateModel.ContentAggregate.Commands;

public class UpdateContentRequestValidator : AbstractValidator<UpdateContentRequest>
{

}

public class UpdateContentRequest : IRequest<UpdateContentResponse>
{
    public Guid ContentId { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public JObject Json { get; set; }
}

public class UpdateContentResponse : ResponseBase
{
    public ContentDto Content { get; set; }
}


public class UpdateContentRequestHandler : IRequestHandler<UpdateContentRequest, UpdateContentResponse>
{
    private readonly ILogger<UpdateContentRequestHandler> _logger;

    private readonly IContentServiceDbContext _context;

    public UpdateContentRequestHandler(ILogger<UpdateContentRequestHandler> logger, IContentServiceDbContext context)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UpdateContentResponse> Handle(UpdateContentRequest request, CancellationToken cancellationToken)
    {
        var content = await _context.Contents.SingleAsync(x => x.ContentId == request.ContentId);

        content.Name = request.Name;

        content.Json = request.Json;

        content.Slug = request.Slug;

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Content = content.ToDto()
        };
    }
}