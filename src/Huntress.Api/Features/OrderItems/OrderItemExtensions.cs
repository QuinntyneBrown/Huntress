using System;
using Huntress.Api.Models;

namespace Huntress.Api.Features
{
    public static class OrderItemExtensions
    {
        public static OrderItemDto ToDto(this OrderItem orderItem)
        {
            return new()
            {
                OrderItemId = orderItem.OrderItemId
            };
        }

    }
}
