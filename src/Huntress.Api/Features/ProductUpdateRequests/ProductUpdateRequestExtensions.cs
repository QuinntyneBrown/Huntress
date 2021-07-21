using Huntress.Api.Models;

namespace Huntress.Api.Features
{
    public static class ProductUpdateRequestExtensions
    {
        public static ProductUpdateRequestDto ToDto(this ProductUpdateRequest productUpdateRequest)
        {
            return new()
            {
                ProductUpdateRequestId = productUpdateRequest.ProductUpdateRequestId,
                Email = productUpdateRequest.Email,
                ProductId = productUpdateRequest.ProductId,
                Updated = productUpdateRequest.Updated,
                Created = productUpdateRequest.Created
            };
        }

    }
}
