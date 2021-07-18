using Huntress.Api.Models;
using System;
using System.Collections.Generic;

namespace Huntress.Api.Features
{
    public class OrderDto
    {
        public System.Guid OrderId { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
        public System.Guid CustomerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public decimal Cost { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
