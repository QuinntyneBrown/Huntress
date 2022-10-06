namespace Huntress.Domain.Enums;

public enum OrderStatus
{
    Draft,
    PreOrder,
    ProcessingPayment,
    Paid,
    Shipped,
    Cancelled,
    Rejected
}
