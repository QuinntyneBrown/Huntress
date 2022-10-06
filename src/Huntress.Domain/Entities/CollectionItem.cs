using System;

namespace Huntress.Domain.Entities
{
    public class CollectionItem
    {
        public Guid CollectionItemId { get; private set; }
        public Guid CollectionId { get; private set; }
        public Guid ProductId { get; private set; }
        public Product Product { get; private set; }

        public CollectionItem(Guid collectionId, Guid productId)
        {
            CollectionId = collectionId;
            ProductId = productId;
        }

        private CollectionItem()
        {

        }
    }
}
