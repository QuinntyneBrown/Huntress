// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.ContentAggregate.Commands;

public class DeleteContentRequestValidator : AbstractValidator<DeleteContentRequest> { }

public class DeleteContentRequest : IRequest<DeleteContentResponse>
{
    public Guid ContentId { get; set; }
}


public class DeleteContentResponse : ResponseBase
{
    public ContentDto Content { get; set; }
}


public class DeleteContentRequestHandler : IRequestHandler<DeleteContentRequest, DeleteContentResponse>
{
    private readonly ILogger<DeleteContentRequestHandler> _logger;

    private readonly IContentServiceDbContext _context;

    public DeleteContentRequestHandler(ILogger<DeleteContentRequestHandler> logger, IContentServiceDbContext context)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<DeleteContentResponse> Handle(DeleteContentRequest request, CancellationToken cancellationToken)
    {
        var content = await _context.Contents.FindAsync(request.ContentId);

        _context.Contents.Remove(content);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Content = content.ToDto()
        };
    }

}



