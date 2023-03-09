// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.JsonSchemaModelAggregate.Queries;

public class GetJsonSchemaModelsRequest: IRequest<GetJsonSchemaModelsResponse> { }

public class GetJsonSchemaModelsResponse: ResponseBase
{
    public List<JsonSchemaModelDto> JsonSchemaModels { get; set; }
}


public class GetJsonSchemaModelsRequestHandler: IRequestHandler<GetJsonSchemaModelsRequest,GetJsonSchemaModelsResponse>
{
    private readonly ILogger<GetJsonSchemaModelsRequestHandler> _logger;

    private readonly IContentServiceDbContext _context;

    public GetJsonSchemaModelsRequestHandler(ILogger<GetJsonSchemaModelsRequestHandler> logger,IContentServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetJsonSchemaModelsResponse> Handle(GetJsonSchemaModelsRequest request,CancellationToken cancellationToken)
    {
        return new () {
            JsonSchemaModels = await _context.JsonSchemaModels.AsNoTracking().ToDtosAsync(cancellationToken)
        };

    }

}



