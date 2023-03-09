// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.JsonSchemaModelAggregate.Queries;

public class GetJsonSchemaModelByIdRequest: IRequest<GetJsonSchemaModelByIdResponse>
{
    public Guid JsonSchemaModelId { get; set; }
}


public class GetJsonSchemaModelByIdResponse: ResponseBase
{
    public JsonSchemaModelDto JsonSchemaModel { get; set; }
}


public class GetJsonSchemaModelByIdRequestHandler: IRequestHandler<GetJsonSchemaModelByIdRequest,GetJsonSchemaModelByIdResponse>
{
    private readonly ILogger<GetJsonSchemaModelByIdRequestHandler> _logger;

    private readonly IContentServiceDbContext _context;

    public GetJsonSchemaModelByIdRequestHandler(ILogger<GetJsonSchemaModelByIdRequestHandler> logger,IContentServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetJsonSchemaModelByIdResponse> Handle(GetJsonSchemaModelByIdRequest request,CancellationToken cancellationToken)
    {
        return new () {
            JsonSchemaModel = (await _context.JsonSchemaModels.AsNoTracking().SingleOrDefaultAsync(x => x.JsonSchemaModelId == request.JsonSchemaModelId)).ToDto()
        };
    }
}