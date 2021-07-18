using System;
using Huntress.Api.Models;

namespace Huntress.Api.Features
{
    public static class OrderExtensions
    {
        public static OrderDto ToDto(this Order order)
        {
            return new ()
            {
                OrderId = order.OrderId
            };
        }
        
    }
}
