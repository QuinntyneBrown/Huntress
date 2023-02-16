// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace DigitalAssetService.Core.AggregateModel.DigitalAssetAggregate.Commands;

public class UploadDigitalAssetRequestValidator: AbstractValidator<UploadDigitalAssetRequest> { }

public class UploadDigitalAssetRequest: IRequest<UploadDigitalAssetResponse>
{
    public Guid DigitalAssetId { get; set; }
    public string Name { get; set; }
    public byte[] Bytes { get; set; }
    public string ContentType { get; set; }
    public float Height { get; set; }
    public float Width { get; set; }
}


public class UploadDigitalAssetResponse: ResponseBase
{
    public DigitalAssetDto DigitalAsset { get; set; }
}


public class UploadDigitalAssetsRequestHandler: IRequestHandler<UploadDigitalAssetRequest,UploadDigitalAssetResponse>
{
    private readonly ILogger<UploadDigitalAssetRequestHandler> _logger;

    private readonly IDigitalAssetServiceDbContext _context;

    public UploadDigitalAssetsRequestHandler(ILogger<UploadDigitalAssetRequestHandler> logger,IDigitalAssetServiceDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UploadDigitalAssetResponse> Handle(UploadDigitalAssetRequest request,CancellationToken cancellationToken){


        return new();
    }

}



