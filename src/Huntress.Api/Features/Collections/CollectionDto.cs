using Huntress.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Huntress.Api.Features
{
    public class CollectionDto
    {
        public Guid? CollectionId { get; set; }
        public CollectionType? CollectionType { get; set; }
        public List<CollectionItemDto> CollectionItems { get; set; } = new();
    }
}
