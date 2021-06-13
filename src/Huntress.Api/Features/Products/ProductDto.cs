using System;
using System.Collections.Generic;

namespace Huntress.Api.Features
{
    public class ProductDto
    {
        public Guid? ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<ProductImageDto> ProductImages { get; set; } = new();
    }
}
