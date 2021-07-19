namespace Huntress.Api.Models
{
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
}
