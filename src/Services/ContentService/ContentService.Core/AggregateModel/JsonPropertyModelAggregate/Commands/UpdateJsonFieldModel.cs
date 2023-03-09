// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.JsonPropertyModelAggregate.Commands;

public class UpdateJsonPropertyModelRequestValidator: AbstractValidator<UpdateJsonPropertyModelRequest> { }

public class UpdateJsonPropertyModelRequest: IRequest<UpdateJsonPropertyModelResponse> {
    public Guid JsonPropertyModelId { get; set; }
    public string Name { get; set; }
}

public class UpdateJsonPropertyModelResponse: ResponseBase
{
    public JsonPropertyModelDto JsonPropertyModel { get; set; }
}


public class UpdateJsonPropertyModelRequestHandler: IRequestHandler<UpdateJsonPropertyModelRequest,UpdateJsonPropertyModelResponse>
{
    private readonly ILogger<UpdateJsonPropertyModelRequestHandler> _logger;

    private readonly IContentServiceDbContext _context;

    public UpdateJsonPropertyModelRequestHandler(ILogger<UpdateJsonPropertyModelRequestHandler> logger,IContentServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UpdateJsonPropertyModelResponse> Handle(UpdateJsonPropertyModelRequest request,CancellationToken cancellationToken)
    {
        var jsonPropertyModel = await _context.JsonPropertyModels.SingleAsync(x => x.JsonPropertyModelId == request.JsonPropertyModelId);

        jsonPropertyModel.Name = request.Name;
        
        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            JsonPropertyModel = jsonPropertyModel.ToDto()
        };

    }

}



