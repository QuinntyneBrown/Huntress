namespace Huntress.Domain.Entities;

public class OrderItem
{
    public Guid OrderItemId { get; set; }
    public Guid OrderId { get; private set; }
    public Guid CatalogItemId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

    public OrderItem()
    {

    }
}
