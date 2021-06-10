using Huntress.Api.Models;
using System;

namespace Huntress.Api.Features
{
    public class ProductCollectionDto
    {
        public Guid? ProductCollectionId { get; set; }
        public ProductCollectionType ProductCollectionType { get; set; }
    }
}
