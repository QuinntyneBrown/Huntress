using System;
using Huntress.Domain.Entities;

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
