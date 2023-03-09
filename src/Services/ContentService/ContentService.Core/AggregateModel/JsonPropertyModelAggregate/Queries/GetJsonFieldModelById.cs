// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.JsonPropertyModelAggregate.Queries;

public class GetJsonPropertyModelByIdRequest: IRequest<GetJsonPropertyModelByIdResponse>
{
    public Guid JsonPropertyModelId { get; set; }
}


public class GetJsonPropertyModelByIdResponse: ResponseBase
{
    public JsonPropertyModelDto JsonPropertyModel { get; set; }
}


public class GetJsonPropertyModelByIdRequestHandler: IRequestHandler<GetJsonPropertyModelByIdRequest,GetJsonPropertyModelByIdResponse>
{
    private readonly ILogger<GetJsonPropertyModelByIdRequestHandler> _logger;

    private readonly IContentServiceDbContext _context;

    public GetJsonPropertyModelByIdRequestHandler(ILogger<GetJsonPropertyModelByIdRequestHandler> logger,IContentServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetJsonPropertyModelByIdResponse> Handle(GetJsonPropertyModelByIdRequest request,CancellationToken cancellationToken)
    {
        return new () {
            JsonPropertyModel = (await _context.JsonPropertyModels.AsNoTracking().SingleOrDefaultAsync(x => x.JsonPropertyModelId == request.JsonPropertyModelId)).ToDto()
        };

    }

}



