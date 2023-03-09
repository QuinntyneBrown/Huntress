// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.JsonSchemaModelAggregate.Queries;

public class GetJsonSchemaModelsPageRequest: IRequest<GetJsonSchemaModelsPageResponse>
{
    public int PageSize { get; set; }
    public int Index { get; set; }
}


public class GetJsonSchemaModelsPageResponse: ResponseBase
{
    public int Length { get; set; }
    public List<JsonSchemaModelDto> Entities  { get; set; }
}


public class GetJsonSchemaModelsPageRequestHandler: IRequestHandler<GetJsonSchemaModelsPageRequest,GetJsonSchemaModelsPageResponse>
{
    private readonly ILogger<GetJsonSchemaModelsPageRequestHandler> _logger;

    private readonly IContentServiceDbContext _context;

    public GetJsonSchemaModelsPageRequestHandler(ILogger<GetJsonSchemaModelsPageRequestHandler> logger,IContentServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetJsonSchemaModelsPageResponse> Handle(GetJsonSchemaModelsPageRequest request,CancellationToken cancellationToken)
    {
        var query = from jsonSchemaModel in _context.JsonSchemaModels
            select jsonSchemaModel;

        var length = await _context.JsonSchemaModels.AsNoTracking().CountAsync();

        var jsonSchemaModels = await query.Page(request.Index, request.PageSize).AsNoTracking()
            .Select(x => x.ToDto()).ToListAsync();

        return new ()
        {
            Length = length,
            Entities = jsonSchemaModels
        };

    }

}



