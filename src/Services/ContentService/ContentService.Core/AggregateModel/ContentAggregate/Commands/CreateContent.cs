// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json.Linq;

namespace ContentService.Core.AggregateModel.ContentAggregate.Commands;

public class CreateContentRequestValidator: AbstractValidator<CreateContentRequest> { }

public class CreateContentRequest: IRequest<CreateContentResponse> {
    public string Name { get; set; }
    public string Slug { get; set; }
    public JObject Json{ get; set; }
}

public class CreateContentResponse: ResponseBase
{
    public ContentDto Content { get; set; }
}


public class CreateContentRequestHandler: IRequestHandler<CreateContentRequest,CreateContentResponse>
{
    private readonly ILogger<CreateContentRequestHandler> _logger;

    private readonly IContentServiceDbContext _context;

    public CreateContentRequestHandler(ILogger<CreateContentRequestHandler> logger,IContentServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<CreateContentResponse> Handle(CreateContentRequest request,CancellationToken cancellationToken)
    {
        var content = new Content(request.Name,request.Slug, request.Json);

        _context.Contents.Add(content);

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Content = content.ToDto()
        };

    }
}