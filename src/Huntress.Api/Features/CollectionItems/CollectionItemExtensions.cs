using Huntress.Domain.Entities;

namespace Huntress.Api.Features
{
    public static class CollectionItemExtensions
    {
        public static CollectionItemDto ToDto(this CollectionItem collectionItem)
        {
            return new()
            {
                CollectionItemId = collectionItem.CollectionItemId,
                Product = collectionItem.Product.ToDto(),
                ProductId = collectionItem.ProductId
            };
        }
    }
}
