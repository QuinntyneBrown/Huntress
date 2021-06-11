using Huntress.Api.Models;
using System;

namespace Huntress.Api.Features
{
    public class CustomerCollectionDto : CollectionDto
    {
        public Guid? CustomerCollectionId { get; set; }
        public CustomerCollectionType CustomerCollectionType { get; set; }
        public Guid CustomerId { get; set; }
    }
}
