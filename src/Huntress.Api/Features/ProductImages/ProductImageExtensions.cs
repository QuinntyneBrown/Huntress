using Huntress.Domain.Entities;

namespace Huntress.Api.Features
{
    public static class ProductImageExtensions
    {
        public static ProductImageDto ToDto(this ProductImage productImage)
        {
            return new()
            {
                ProductImageId = productImage.ProductImageId,
                Name = productImage.Name,
                ImageUrl = productImage.ImageUrl
            };
        }

    }
}
