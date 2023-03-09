// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.JsonPropertyModelAggregate.Queries;

public class GetJsonPropertyModelsPageRequest: IRequest<GetJsonPropertyModelsPageResponse>
{
    public int PageSize { get; set; }
    public int Index { get; set; }
}


public class GetJsonPropertyModelsPageResponse: ResponseBase
{
    public int Length { get; set; }
    public List<JsonPropertyModelDto> Entities  { get; set; }
}


public class GetJsonPropertyModelsPageRequestHandler: IRequestHandler<GetJsonPropertyModelsPageRequest,GetJsonPropertyModelsPageResponse>
{
    private readonly ILogger<GetJsonPropertyModelsPageRequestHandler> _logger;

    private readonly IContentServiceDbContext _context;

    public GetJsonPropertyModelsPageRequestHandler(ILogger<GetJsonPropertyModelsPageRequestHandler> logger,IContentServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetJsonPropertyModelsPageResponse> Handle(GetJsonPropertyModelsPageRequest request,CancellationToken cancellationToken)
    {
        var query = from jsonPropertyModel in _context.JsonPropertyModels
            select jsonPropertyModel;

        var length = await _context.JsonPropertyModels.AsNoTracking().CountAsync();

        var jsonPropertyModels = await query.Page(request.Index, request.PageSize).AsNoTracking()
            .Select(x => x.ToDto()).ToListAsync();

        return new ()
        {
            Length = length,
            Entities = jsonPropertyModels
        };

    }

}



