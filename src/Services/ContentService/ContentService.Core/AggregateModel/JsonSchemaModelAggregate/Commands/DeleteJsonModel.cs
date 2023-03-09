// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.JsonSchemaModelAggregate.Commands;

public class DeleteJsonSchemaModelRequestValidator: AbstractValidator<DeleteJsonSchemaModelRequest> { }

public class DeleteJsonSchemaModelRequest: IRequest<DeleteJsonSchemaModelResponse>
{
    public Guid JsonSchemaModelId { get; set; }
}


public class DeleteJsonSchemaModelResponse: ResponseBase
{
    public JsonSchemaModelDto JsonSchemaModel { get; set; }
}


public class DeleteJsonSchemaModelRequestHandler: IRequestHandler<DeleteJsonSchemaModelRequest,DeleteJsonSchemaModelResponse>
{
    private readonly ILogger<DeleteJsonSchemaModelRequestHandler> _logger;

    private readonly IContentServiceDbContext _context;

    public DeleteJsonSchemaModelRequestHandler(ILogger<DeleteJsonSchemaModelRequestHandler> logger,IContentServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<DeleteJsonSchemaModelResponse> Handle(DeleteJsonSchemaModelRequest request,CancellationToken cancellationToken)
    {
        var jsonSchemaModel = await _context.JsonSchemaModels.FindAsync(request.JsonSchemaModelId);

        _context.JsonSchemaModels.Remove(jsonSchemaModel);

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            JsonSchemaModel = jsonSchemaModel.ToDto()
        };
    }

}



