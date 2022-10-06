using Huntress.Domain.Enums;

namespace Huntress.Domain.Exceptions;

public class UnableToChangePreOrderPaymentStatusException : Exception
{
    public UnableToChangePreOrderPaymentStatusException(OrderStatus orderStatus)
        : base($"Unable to change to PreOrder Status $({OrderStatus.PreOrder}) due to current status of {orderStatus}")
    { }
}