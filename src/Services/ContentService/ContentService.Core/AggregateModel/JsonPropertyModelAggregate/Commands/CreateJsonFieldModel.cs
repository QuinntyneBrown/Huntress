// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.JsonPropertyModelAggregate.Commands;

public class CreateJsonPropertyModelRequestValidator: AbstractValidator<CreateJsonPropertyModelRequest> { }

public class CreateJsonPropertyModelRequest: IRequest<CreateJsonPropertyModelResponse> {

    public string Name { get; set; }
}

public class CreateJsonPropertyModelResponse: ResponseBase
{
    public JsonPropertyModelDto JsonPropertyModel { get; set; }
}


public class CreateJsonPropertyModelRequestHandler: IRequestHandler<CreateJsonPropertyModelRequest,CreateJsonPropertyModelResponse>
{
    private readonly ILogger<CreateJsonPropertyModelRequestHandler> _logger;

    private readonly IContentServiceDbContext _context;

    public CreateJsonPropertyModelRequestHandler(ILogger<CreateJsonPropertyModelRequestHandler> logger,IContentServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<CreateJsonPropertyModelResponse> Handle(CreateJsonPropertyModelRequest request,CancellationToken cancellationToken)
    {
        var jsonPropertyModel = new JsonPropertyModel(request.Name);

        _context.JsonPropertyModels.Add(jsonPropertyModel);

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            JsonPropertyModel = jsonPropertyModel.ToDto()
        };

    }

}



