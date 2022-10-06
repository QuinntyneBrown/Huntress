using Huntress.Domain.Entities;
using System;

namespace Huntress.Api.Features
{
    public class ProductCollectionDto
    {
        public Guid? ProductCollectionId { get; set; }
        public ProductCollectionType ProductCollectionType { get; set; }
    }
}
