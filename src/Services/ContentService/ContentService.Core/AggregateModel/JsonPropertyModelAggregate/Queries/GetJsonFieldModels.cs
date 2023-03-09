// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.JsonPropertyModelAggregate.Queries;

public class GetJsonPropertyModelsRequest: IRequest<GetJsonPropertyModelsResponse> { }

public class GetJsonPropertyModelsResponse: ResponseBase
{
    public List<JsonPropertyModelDto> JsonPropertyModels { get; set; }
}


public class GetJsonPropertyModelsRequestHandler: IRequestHandler<GetJsonPropertyModelsRequest,GetJsonPropertyModelsResponse>
{
    private readonly ILogger<GetJsonPropertyModelsRequestHandler> _logger;

    private readonly IContentServiceDbContext _context;

    public GetJsonPropertyModelsRequestHandler(ILogger<GetJsonPropertyModelsRequestHandler> logger,IContentServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetJsonPropertyModelsResponse> Handle(GetJsonPropertyModelsRequest request,CancellationToken cancellationToken)
    {
        return new () {
            JsonPropertyModels = await _context.JsonPropertyModels.AsNoTracking().ToDtosAsync(cancellationToken)
        };

    }

}



