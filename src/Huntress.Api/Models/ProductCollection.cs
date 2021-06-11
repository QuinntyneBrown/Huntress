using System;

namespace Huntress.Api.Models
{
    public class ProductCollection : Collection
    {
        public Guid ProductCollectionId { get; set; }
        public ProductCollectionType ProductCollectionType { get; set; } = ProductCollectionType.YouMayAlsoLike;

        public ProductCollection(ProductCollectionType productCollectionType)
        {
            ProductCollectionType = productCollectionType;
        }

        private ProductCollection()
        {

        }

    }
}
