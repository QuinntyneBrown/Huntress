// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.JsonSchemaModelAggregate.Commands;

public class UpdateJsonSchemaModelRequestValidator: AbstractValidator<UpdateJsonSchemaModelRequest> { }

public class UpdateJsonSchemaModelRequest: IRequest<UpdateJsonSchemaModelResponse> {
    public Guid JsonSchemaModelId { get; set; }
    public string Name { get; set; }
}

public class UpdateJsonSchemaModelResponse: ResponseBase
{
    public JsonSchemaModelDto JsonSchemaModel { get; set; }
}


public class UpdateJsonSchemaModelRequestHandler: IRequestHandler<UpdateJsonSchemaModelRequest,UpdateJsonSchemaModelResponse>
{
    private readonly ILogger<UpdateJsonSchemaModelRequestHandler> _logger;

    private readonly IContentServiceDbContext _context;

    public UpdateJsonSchemaModelRequestHandler(ILogger<UpdateJsonSchemaModelRequestHandler> logger,IContentServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UpdateJsonSchemaModelResponse> Handle(UpdateJsonSchemaModelRequest request,CancellationToken cancellationToken)
    {
        var jsonSchemaModel = await _context.JsonSchemaModels.SingleAsync(x => x.JsonSchemaModelId == request.JsonSchemaModelId);

        jsonSchemaModel.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            JsonSchemaModel = jsonSchemaModel.ToDto()
        };

    }

}



