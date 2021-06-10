using System;

namespace Huntress.Api.Features
{
    public class ProductImageDto
    {
        public Guid? ProductImageId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
