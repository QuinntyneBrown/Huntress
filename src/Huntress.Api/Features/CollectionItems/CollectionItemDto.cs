using System;

namespace Huntress.Api.Features
{
    public class CollectionItemDto
    {
        public Guid? CollectionItemId { get; set; }
        public Guid CollectionId { get; set; }
        public Guid ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}
