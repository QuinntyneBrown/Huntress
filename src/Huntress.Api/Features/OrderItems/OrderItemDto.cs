using System;

namespace Huntress.Api.Features
{
    public class OrderItemDto
    {
        public System.Guid? OrderItemId { get; set; }
        public System.Guid OrderId { get; set; }
        public System.Guid CatalogItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
