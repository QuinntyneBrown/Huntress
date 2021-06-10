using Huntress.Api.Models;

namespace Huntress.Api.Features
{
    public static class ProductCollectionExtensions
    {
        public static ProductCollectionDto ToDto(this ProductCollection productCollection)
        {
            return new ()
            {
                ProductCollectionId = productCollection.ProductCollectionId,
                ProductCollectionType = productCollection.ProductCollectionType
            };
        }
        
    }
}
