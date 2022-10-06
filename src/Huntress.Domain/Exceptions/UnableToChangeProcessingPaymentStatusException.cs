using Huntress.Domain.Enums;

namespace Huntress.Domain.Exceptions;

public class UnableToChangeProcessingPaymentStatusException: Exception
{
	public UnableToChangeProcessingPaymentStatusException(OrderStatus orderStatus)
		:base($"Unable to change to Processing Payment Status $({OrderStatus.ProcessingPayment}) due to current status of {orderStatus}")
	{ }
}
