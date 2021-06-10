using System;

namespace Huntress.Api.Models
{
    public class Product
    {
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public Product(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }

        private Product()
        {

        }
    }
}
