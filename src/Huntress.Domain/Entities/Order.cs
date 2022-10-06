using System.Collections.Generic;
using Huntress.Domain.Enums;
using Huntress.Domain.Exceptions;

namespace Huntress.Domain.Entities;

public class Order
{
    public Guid OrderId { get; set; }
    public Guid CustomerId { get; set; }
    public decimal Cost { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Draft;
    public List<OrderItem> OrderItems { get; set; } = new();
    public DateTime OrderDate { get; set; }
    public Address ShippingAddress { get; set; } = null!;
    public Address BillingAddress { get; set; } = null!;

    public Order(
        Guid customerId,
        decimal cost,
        OrderStatus status,
        DateTime orderDate,
        Address shippingAddress,
        Address billingAddress
        )
    {
        CustomerId = customerId;
        Cost = cost;
        Status = status;
        OrderDate = orderDate;
        ShippingAddress = shippingAddress;
        BillingAddress = billingAddress;
    }

    private Order()
    {

    }

    public Order SetProcessingPaymentStatus()
    {
        if (Status == OrderStatus.ProcessingPayment || Status == OrderStatus.Paid)
        {
            throw new UnableToChangeProcessingPaymentStatusException(Status);
        }

        Status = OrderStatus.ProcessingPayment;
        return this;
    }

    public Order SetPreOrderStatus()
    {
        if (Status != OrderStatus.Draft)
        {
            throw new UnableToChangePreOrderPaymentStatusException(Status);
        }

        Status = OrderStatus.PreOrder;
        return this;
    }

    public Order SetPaidStatus()
    {
        Status = OrderStatus.Paid;
        return this;
    }

    public Order SetShippedStatus()
    {
        Status = OrderStatus.Shipped;
        return this;
    }

    public Order SetRejectedStatus()
    {
        Status = OrderStatus.Rejected;
        return this;
    }

    public Order SetCancelledStatus()
    {
        if (Status == OrderStatus.Paid || Status == OrderStatus.Shipped)
        {
            throw new Exception();
        }

        Status = OrderStatus.Cancelled;
        return this;
    }
}
