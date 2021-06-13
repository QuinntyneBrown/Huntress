using Huntress.Api.Models;
using System.Linq;

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
                Description = product.Description,
                ProductImages = product.ProductImages.Select(x => x.ToDto()).ToList()
            };
        }
    }
}
