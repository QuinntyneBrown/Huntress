using System;

namespace Huntress.Domain.Entities;

public class ProductImage
{
    public Guid ProductImageId { get; private set; }
    public string Name { get; private set; } = "";
    public string ImageUrl { get; private set; } = "";
    public ProductImage(string name, string imageUrl)
    {
        Name = name;
        ImageUrl = imageUrl;
    }

    private ProductImage()
    {

    }
}
