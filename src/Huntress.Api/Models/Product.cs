using System;
using System.Collections.Generic;

namespace Huntress.Api.Models
{
    public class Product
    {
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public int QuantityInStock { get; set; }
        public bool OnReOrder { get; set; }
        public int InventoryCount { get; set; } = 0;
        public List<ProductImage> ProductImages { get; private set; } = new();
        public Product(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }

        private Product()
        {

        }

        public Product AddStock(int quantity)
        {
            QuantityInStock += quantity;

            return this;
        }

        public Product RemoveStock(int quantity)
        {
            if (QuantityInStock == 0)
            {
                throw new Exception();
            }

            if (quantity > QuantityInStock)
            {
                throw new Exception();
            }

            QuantityInStock -= quantity;

            return this;
        }
    }
}
