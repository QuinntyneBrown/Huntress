using Huntress.Api.Models;

namespace Huntress.Api.Features
{
    public static class ProductExtensions
    {
        public static ProductDto ToDto(this Product product)
        {
            return new()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };
        }
    }
}
