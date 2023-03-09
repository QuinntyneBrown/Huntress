// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.JsonPropertyModelAggregate.Commands;

public class DeleteJsonPropertyModelRequestValidator: AbstractValidator<DeleteJsonPropertyModelRequest> { }

public class DeleteJsonPropertyModelRequest: IRequest<DeleteJsonPropertyModelResponse>
{
    public Guid JsonPropertyModelId { get; set; }
}


public class DeleteJsonPropertyModelResponse: ResponseBase
{
    public JsonPropertyModelDto JsonPropertyModel { get; set; }
}


public class DeleteJsonPropertyModelRequestHandler: IRequestHandler<DeleteJsonPropertyModelRequest,DeleteJsonPropertyModelResponse>
{
    private readonly ILogger<DeleteJsonPropertyModelRequestHandler> _logger;

    private readonly IContentServiceDbContext _context;

    public DeleteJsonPropertyModelRequestHandler(ILogger<DeleteJsonPropertyModelRequestHandler> logger,IContentServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<DeleteJsonPropertyModelResponse> Handle(DeleteJsonPropertyModelRequest request,CancellationToken cancellationToken)
    {
        var jsonPropertyModel = await _context.JsonPropertyModels.FindAsync(request.JsonPropertyModelId);

        _context.JsonPropertyModels.Remove(jsonPropertyModel);

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            JsonPropertyModel = jsonPropertyModel.ToDto()
        };
    }

}



